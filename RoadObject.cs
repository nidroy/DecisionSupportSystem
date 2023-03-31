using System.Data;

namespace DecisionSupportSystem
{
    public partial class RoadObject : Form
    {
        public RoadObject()
        {
            InitializeComponent();
            SelectRoadObject();
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

        private void showWorks_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            RoadWork roadWork = new RoadWork(id);
            roadWork.ShowDialog();
        }
    }
}
