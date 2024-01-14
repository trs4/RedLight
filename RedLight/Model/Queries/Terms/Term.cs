namespace RedLight;

/// <summary>Условие</summary>
public abstract class Term : Query
{
    protected Term(Query owner) : base(owner?.Connection, owner) { }
}
