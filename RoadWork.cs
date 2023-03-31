

using System.Data;

namespace DecisionSupportSystem
{
    public partial class RoadWork : Form
    {
        private int id;

        public RoadWork(int id)
        {
            InitializeComponent();
            this.id = id;
            SelectRoadObject();
        }


        private void SelectRoadObject()
        {
            DataSet ds = DatabaseContext.ExecuteQuery(string.Format("" +
                "SELECT DISTINCT " +
                "[Month].[name] as [Месяц проведения работы], " +
                "[Year].[number] as [Год проведения работы], " +
                "[RoadWork].[name] as [Название работы], " +
                "[RoadWork].[unit] as [Единица измерения], " +
                "[RoadWork].[price] as [Стоимость единицы], " +
                "[Plan_Object_Work].[count] as [Количество работ], " +
                "[Plan_Object_Work].[price] as [Стоимость всей работы] " +
                "FROM [Plan_Object_Work] " +
                "JOIN [RoadWork] " +
                "ON [Plan_Object_Work].[work_id] = [RoadWork].[id] " +
                "JOIN [Plan] " +
                "ON [Plan_Object_Work].[plan_id] = [Plan].[id] " +
                "CROSS JOIN [PlanReportResult] " +
                "JOIN [MonthPlan] " +
                "ON [PlanReportResult].[id] = [MonthPlan].[planReportResult_id] " +
                "JOIN [Date] " +
                "ON [MonthPlan].[date_id] = [Date].[id] " +
                "JOIN [Month] " +
                "ON [Date].[month_id] = [Month].[id] " +
                "JOIN [Year] " +
                "ON [Date].[year_id] = [Year].[id] " +
                "WHERE [Plan_Object_Work].[object_id] = {0};", id));

            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
