using System.Data;

namespace DecisionSupportSystem
{
    public partial class RoadObject : Form
    {
        public RoadObject()
        {
            InitializeComponent();
            SelectRoadObject();

            DataSet ds = DatabaseContext.ExecuteQuery("" +
                "SELECT [number] " +
                "FROM [Date] " +
                "JOIN [Year] " +
                "ON [Date].[year_id] = [Year].[id];");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void SelectRoadObject()
        {
            DataSet ds = DatabaseContext.ExecuteQuery("" +
                "SELECT " +
                "[id] as [Идентификатор], " +
                "[name] as [Название], " +
                "[passport] as [Паспорт объекта], " +
                "[priority] as [Приоритет ремонта] " +
                "FROM [RoadObject];");

            dataGridView.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
