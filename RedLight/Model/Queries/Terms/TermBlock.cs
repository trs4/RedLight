using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Блок условий</summary>
public sealed class TermBlock : Term, IList<Term>
{
    private static readonly FrozenDictionary<LogicalOperator, string> _logicalOperatorToString = new Dictionary<LogicalOperator, string>()
    {
        { LogicalOperator.And, " AND " },
        { LogicalOperator.Or, " OR " },
    }.ToFrozenDictionary();

    /// <summary>Список условий</summary>
    private readonly List<Term> _terms = new(2);

    internal TermBlock(Query owner) : base(owner) { }

    /// <summary>Логический оператор между условиями в блоке</summary>
    public LogicalOperator LogicalOperator { get; set; }

    /// <summary>Указывает на то, что перед IN надо поставить NOT (NOT IN (...))</summary>
    public bool Not { get; set; }

    /// <summary>Указывает, что условий в блоке нет</summary>
    public bool IsEmpty => _terms.Count == 0;

    /// <summary>Добавляет вложенный блок условий</summary>
    public TermBlock AddTermBlock()
    {
        var innerTermBlock = new TermBlock(this);
        _terms.Add(innerTermBlock);
        return innerTermBlock;
    }

    #region Internal

    [MethodImpl(Flags.HotPath)]
    internal void AddTerm(Term term) => _terms.Add(term);

    private List<Term> EscapeTerms()
    {
        if (_terms.Count == 0 || !_terms.OfType<TermBlock>().Any())
            return _terms;

        var terms = new List<Term>(_terms.Count);

        foreach (var term in _terms)
        {
            if (term is TermBlock termBlock)
            {
                var childTerms = termBlock.EscapeTerms();

                if (childTerms.Count == 0)
                    continue;
            }

            terms.Add(term);
        }

        return terms;
    }

    internal void BuildSql(StringBuilder builder, QueryOptions options, string name, TermBlock additionalBlockTerm = null)
    {
        var terms = EscapeTerms();
        var additionalTerms = additionalBlockTerm?.EscapeTerms();
        bool hasTerms = terms.Count > 0;
        bool hasAdditionalTerms = !additionalTerms.IsNullOrEmpty();

        if (!hasTerms && !hasAdditionalTerms)
            return;

        if (name is not null)
            builder.Append(name).Append(' ');

        if (terms.Count > 0)
        {
            bool addBrackets = terms.Count > 1;

            if (Not)
                builder.Append("NOT ");

            if (addBrackets)
                builder.Append('(');

            terms[0].BuildSql(builder, options);
            string operatorName = _logicalOperatorToString[LogicalOperator];

            for (int i = 1; i < terms.Count; i++)
            {
                builder.Append(operatorName);
                terms[i].BuildSql(builder, options);
            }

            if (addBrackets)
                builder.Append(')');
        }

        if (hasAdditionalTerms)
        {
            bool addBrackets = additionalTerms.Count > 1;

            if (hasTerms)
                builder.Append(" AND ");

            if (additionalBlockTerm.Not)
                builder.Append("NOT ");

            if (addBrackets)
                builder.Append('(');

            additionalTerms[0].BuildSql(builder, options);
            string operatorName = _logicalOperatorToString[additionalBlockTerm.LogicalOperator];

            for (int i = 1; i < additionalTerms.Count; i++)
            {
                builder.Append(operatorName);
                additionalTerms[i].BuildSql(builder, options);
            }

            if (addBrackets)
                builder.Append(')');
        }
    }

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSql(builder, options, null);

    #endregion
    #region IList

    public int Count => _terms.Count;

    public Term this[int index]
    {
        get => _terms[index];
        set => _terms[index] = value ?? throw new ArgumentNullException(nameof(value));
    }

    bool ICollection<Term>.IsReadOnly => false;

    public void Add(Term term) => _terms.Add(term ?? throw new ArgumentNullException(nameof(term)));

    public void Clear() => _terms.Clear();

    public bool Contains(Term term) => _terms.Contains(term);

    void ICollection<Term>.CopyTo(Term[] array, int arrayIndex) => _terms.CopyTo(array, arrayIndex);

    IEnumerator<Term> IEnumerable<Term>.GetEnumerator() => _terms.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _terms.GetEnumerator();

    public int IndexOf(Term term) => _terms.IndexOf(term);

    public void Insert(int index, Term term) => _terms.Insert(index, term ?? throw new ArgumentNullException(nameof(term)));

    public bool Remove(Term term) => _terms.Remove(term);

    public void RemoveAt(int index) => _terms.RemoveAt(index);

    #endregion
}
