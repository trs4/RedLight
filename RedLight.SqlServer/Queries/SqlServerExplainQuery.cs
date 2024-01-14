using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IcyRain.Tables;

namespace RedLight.SqlServer;

internal sealed class SqlServerExplainQuery : ExplainQuery
{
    public SqlServerExplainQuery(Query owner) : base(owner) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        if (LiveStatistics)
            builder.Append("BEGIN TRAN\r\nGO\r\nSET STATISTICS XML ON;\r\nGO\r\n\r\n");
        else
            builder.Append("SET SHOWPLAN_ALL ON;\r\nGO\r\n\r\n");

        Owner.BuildSql(builder, options);

        if (LiveStatistics)
            builder.Append("\r\n\r\nGO\r\nSET STATISTICS XML OFF;\r\nGO\r\nROLLBACK TRAN");
        else
            builder.Append("\r\n\r\nGO\r\nSET SHOWPLAN_ALL OFF;");
    }

    protected override string GetPlan(int timeout)
    {
        if (LiveStatistics)
        {
            Connection.Run("SET STATISTICS XML ON", null, timeout);
            string xml = Connection.Get<string>(Owner.Sql, null, timeout);
            Connection.Run("SET STATISTICS XML OFF", null, timeout);
            return xml;
        }
        else
        {
            Connection.Run("SET SHOWPLAN_ALL ON", null, timeout);
            var dataTable = Connection.Get<DataTable>(Owner.Sql, null, timeout);
            Connection.Run("SET SHOWPLAN_ALL OFF", null, timeout);
            return dataTable.GetView();
        }
    }

    protected async override Task<string> GetPlanAsync(int timeout, CancellationToken token)
    {
        if (LiveStatistics)
        {
            await Connection.RunAsync("SET STATISTICS XML ON", null, timeout, token).ConfigureAwait(false);
            string xml = await Connection.GetAsync<string>(Owner.Sql, null, timeout, token).ConfigureAwait(false);
            await Connection.RunAsync("SET STATISTICS XML OFF", null, timeout, token).ConfigureAwait(false);
            return xml;
        }
        else
        {
            await Connection.RunAsync("SET SHOWPLAN_ALL ON", null, timeout, token).ConfigureAwait(false);
            var dataTable = await Connection.GetAsync<DataTable>(Owner.Sql, null, timeout, token).ConfigureAwait(false);
            await Connection.RunAsync("SET SHOWPLAN_ALL OFF", null, timeout, token).ConfigureAwait(false);
            return dataTable.GetView();
        }
    }

    protected override string GetQueryPlanExtension() => LiveStatistics ? ".sqlplan" : base.GetQueryPlanExtension();
}
