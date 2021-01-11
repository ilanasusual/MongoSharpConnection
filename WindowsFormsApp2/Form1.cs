using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

       
        
       

        private void Form1_Load(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:Qwerty123@ilhan152120161034.n9ayt.mongodb.net/sample_training?retryWrites=true&w=majority");
            var db = dbClient.GetDatabase("bigDataOdev");
            var collection = db.GetCollection<grades>("grades");

        }

        public void ReadAllDocuments()
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:Qwerty123@ilhan152120161034.n9ayt.mongodb.net/sample_training?retryWrites=true&w=majority");
            var db = dbClient.GetDatabase("bigDataOdev");
            var collection = db.GetCollection<grades>("grades");
            List<grades> list = collection.AsQueryable().ToList<grades>();
            dataGridView1.DataSource = list;
            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:Qwerty123@ilhan152120161034.n9ayt.mongodb.net/sample_training?retryWrites=true&w=majority");
            var db = dbClient.GetDatabase("bigDataOdev");
            var collection = db.GetCollection<grades>("grades");

          grades g = new grades(textBox2.Text, double.Parse(textBox3.Text));
            collection.InsertOne(g);
            ReadAllDocuments();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:Qwerty123@ilhan152120161034.n9ayt.mongodb.net/sample_training?retryWrites=true&w=majority");
            var db = dbClient.GetDatabase("bigDataOdev");
            var collection = db.GetCollection<grades>("grades");

            var updateDef = Builders<grades>.Update.Set("student_id", textBox2.Text).Set("class_id", textBox3.Text);
            collection.UpdateOne(g => g._id == ObjectId.Parse(textBox1.Text), updateDef);
            ReadAllDocuments();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient("mongodb+srv://admin:Qwerty123@ilhan152120161034.n9ayt.mongodb.net/sample_training?retryWrites=true&w=majority");
            var db = dbClient.GetDatabase("bigDataOdev");
            var collection = db.GetCollection<grades>("grades");

            collection.DeleteOne(g => g._id == ObjectId.Parse(textBox1.Text));
            ReadAllDocuments();
        }
    }
}
