using ChatBot;
using System.Text;

namespace Testing
{
    public partial class frmTestingBot : Form
    {
        public frmTestingBot()
        {
            InitializeComponent();
            txtQuestion.KeyDown += new KeyEventHandler(txtQuestion_KeyDown);
        }
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOldChats = new StringBuilder();


        private void button1_Click(object sender, EventArgs e)
        {
            SetChatInformation();
        }

        private void SetChatInformation()
        {
            Consumption objConsume = new Consumption();
            sb.Clear();
            string question = $"Q: {txtQuestion.Text.Trim()}"; ;
            string answer = $"A: {objConsume.TestSingleQuestion(txtQuestion.Text.Trim(), objConsume.TestSingleContext(txtQuestion.Text.Trim()))}";
            sb.AppendLine(question);
            sb.AppendLine(answer);
            sb.AppendLine("");
            sb.Append(sbOldChats.ToString());

            sbOldChats.AppendLine(question);
            sbOldChats.AppendLine(answer);
            sbOldChats.AppendLine("");

            txtAnswer.Text = sb.ToString();
            txtQuestion.Text = string.Empty;
        }
        private void resetChat_Click(object sender, EventArgs e)
        {
            txtQuestion.Text = string.Empty;
            sb = new StringBuilder();
            sbOldChats = new StringBuilder();
            txtAnswer.Text = string.Empty;
        }
        private void txtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetChatInformation();
                e.SuppressKeyPress = true;
            }
        }

        private void Training_Click(object sender, EventArgs e)
        {
            TrainingModels objTrain = new TrainingModels();
            objTrain.Train();
            objTrain.ContestTrain();
        }

        private void frmTestingBot_Load(object sender, EventArgs e)
        {

        }
    }
}
