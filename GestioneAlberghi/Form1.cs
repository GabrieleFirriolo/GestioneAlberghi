using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace GestioneAlberghi
{
    public partial class Form1 : Form
    {
        stanza[] elestanze = new stanza[500];
        int num = default;
        string a = "ArchivioGestioneAlbergo.txt";
        public Form1()
        {
            Class1.Carica(elestanze, ref num, a);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void butadd_creazione_Click(object sender, EventArgs e)
        {
            stanza nuovastanza = default;
            
        
        int f = Class1.Cerca1(elestanze, num, textnum_creazione.Text);
            if (f!=-1)
            {
                MessageBox.Show("Numero stanza già usato");
                textnum_creazione.Clear();
                textposti_creazione.Clear();
                textcosto_creazione.Clear();
                return;
            }


            try
            {
                nuovastanza.numero = int.Parse(textnum_creazione.Text);
                nuovastanza.posti = int.Parse(textposti_creazione.Text);
                nuovastanza.costo = decimal.Parse(textcosto_creazione.Text);
                if (comboBox1.Text == "Occupato")
                {
                    nuovastanza.stato = false;
                }
                if (comboBox1.Text == "Libera")
                {
                    nuovastanza.stato = true;
                }
                
                elestanze[num] = nuovastanza;
                num++;

                textnum_creazione.Clear();
                textposti_creazione.Clear();
                textcosto_creazione.Clear();

                MessageBox.Show("Stanza inserita");
            }
            catch
            {
                MessageBox.Show("Dati inseriti non validi");
                textnum_creazione.Clear();
                textposti_creazione.Clear();
                textcosto_creazione.Clear();
                comboBox1.Text = "";
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                string appoggio=default;
                int x = default(int);
                listView1.Items.Clear();
               
                
                while (x < num)
                {
                    if (elestanze[x].stato == true)
                    {
                        appoggio = "Libera";
                    }
                    if (elestanze[x].stato == false)
                    {
                        appoggio = "Occupata";
                    }
                    var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                    var listrow = new ListViewItem(row);
                    listView1.Items.Add(listrow);
                    x = x + 1;
                }
            }

            if (tabControl1.SelectedIndex == 2)
            {
                string appoggio = default;
                int x = default(int);
                listView2.Items.Clear();
                
                while (x < num)
                {
                    if (elestanze[x].stato == true)
                    {
                        appoggio = "Libera";
                    }
                    if (elestanze[x].stato == false)
                    {
                        appoggio = "Occupata";
                    }
                    var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(),appoggio };
                    var listrow = new ListViewItem(row);
                    listView2.Items.Add(listrow);
                    x = x + 1;
                }
            }

            if (tabControl1.SelectedIndex == 4)
            {
                string appoggio = default;
                int x = default(int);
                listView3.Items.Clear();
                
                while (x < num)
                {
                    if (elestanze[x].stato == true)
                    {
                        appoggio = "Libera";
                    }
                    if (elestanze[x].stato == false)
                    {
                        appoggio = "Occupata";
                    }
                    if (elestanze[x].stato == true)
                    {
                        var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                        var listrow = new ListViewItem(row);
                        listView3.Items.Add(listrow);
                    }
                    x = x + 1;
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "N° Stanza(crescente)")
            {
                Class1.ordinac(elestanze, num);
            }

            if (comboBox2.Text == "N° Stanza (decrescente)")
            {
                Class1.ordinad(elestanze, num);
            }

            if (comboBox2.Text == "Costo (crescente)")
            {
                Class1.ordinacc(elestanze, num);
            }

            if (comboBox2.Text == "Costo (decrescente)")
            {
                Class1.ordinadc(elestanze, num);
            }
            if (comboBox2.Text == "Stato (libera)")
            {
                Class1.ordinacs(elestanze, num);
            }

            string appoggio = default;
            int x = default(int);
            listView1.Items.Clear();
           
            while (x < num)
            {
                if (elestanze[x].stato == true)
                {
                    appoggio = "Libera";
                }
                if (elestanze[x].stato == false)
                {
                    appoggio = "Occupata";
                }
                var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                var listrow = new ListViewItem(row);
                listView1.Items.Add(listrow);
                x = x + 1;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int z = default;
                int k = listView2.SelectedIndices.Count;
                if (k != 0)
                {
                    z = Class1.Cerca1(elestanze, num, listView2.SelectedItems[0].SubItems[0].Text);
                }
                textnum_modifica.Text = elestanze[z].numero.ToString();
                textposti_modifica.Text = elestanze[z].posti.ToString();
                textcosto_modifica.Text = elestanze[z].costo.ToString();
                if (elestanze[z].stato == true)
                {
                    comboBox2.SelectedText = "Libera";
                }
                if (elestanze[z].stato == false)
                {
                    comboBox2.SelectedText = "Occupata";
                }
            }
            catch
            {

            }
        }

        private void butrel_modifica_Click(object sender, EventArgs e)
        {
            stanza nuovastanza = default;
            int f = Class1.Cerca1(elestanze, num, textnum_creazione.Text);
            if (f != -1)
            {
                MessageBox.Show("Numero stanza già usato");
                textnum_modifica.Clear();
                textposti_modifica.Clear();
                textcosto_modifica.Clear();
                return;
            }
            try
            {
                int z = default;
                int k = listView2.SelectedIndices.Count;
                if (k != 0)
                {
                    z = Class1.Cerca1(elestanze, num, listView2.SelectedItems[0].SubItems[0].Text);
                }
                nuovastanza.numero = int.Parse(textnum_modifica.Text);
                nuovastanza.posti = int.Parse(textposti_modifica.Text);
                nuovastanza.costo = decimal.Parse(textcosto_modifica.Text);
                if (comboBox2.Text == "Occupato")
                {
                    nuovastanza.stato = false;
                }
                if (comboBox2.Text == "Libera")
                {
                    nuovastanza.stato = true;
                }

                elestanze[z] = nuovastanza;


                textnum_modifica.Clear();
                textposti_modifica.Clear();
                textcosto_modifica.Clear();

                MessageBox.Show("Stanza modificata");
                string appoggio = default;
                int x = default(int);
                listView2.Items.Clear();
             
                while (x < num)
                {
                    if (elestanze[x].stato == true)
                    {
                        appoggio = "Libera";
                    }
                    if (elestanze[x].stato == false)
                    {
                        appoggio = "Occupata";
                    }
                    var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                    var listrow = new ListViewItem(row);
                    listView2.Items.Add(listrow);
                    x = x + 1;
                }
            }
            catch
            {
                textnum_modifica.Clear();
                textposti_modifica.Clear();
                textcosto_modifica.Clear();

                MessageBox.Show("Stanza non modificata, controllare i valori immessi");
                string appoggio = default;
                int x = default(int);
                listView2.Items.Clear();
              
                while (x < num)
                {
                    if (elestanze[x].stato == true)
                    {
                        appoggio = "Libera";
                    }
                    if (elestanze[x].stato == false)
                    {
                        appoggio = "Occupata";
                    }
                    var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                    var listrow = new ListViewItem(row);
                    listView2.Items.Add(listrow);
                    x = x + 1;
                }
            }


        }

        private void butelimina_modifica_Click(object sender, EventArgs e)
        {
            int q = default(int);
            string cod = default(string);

            cod = textnum_modifica.Text;
            q = Class1.elimina(elestanze, ref num, cod);
            if (q > 0)
            {
                MessageBox.Show("Hai eliminato " + q + " stanze");
            }


            textnum_modifica.Clear();
            textposti_modifica.Clear();
            textcosto_modifica.Clear();


            string appoggio = default;
            int x = default(int);
            listView2.Items.Clear();
            
            while (x < num)
            {
                if (elestanze[x].stato == true)
                {
                    appoggio = "Libera";
                }
                if (elestanze[x].stato == false)
                {
                    appoggio = "Occupata";
                }
                var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                var listrow = new ListViewItem(row);
                listView2.Items.Add(listrow);
                x = x + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string p = default(string);
            p = "ArchivioGestioneAlbergo.txt";
            Class1.salva(elestanze, num, p);
            MessageBox.Show("Hai salvato");
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int z = default;
                int k = listView3.SelectedIndices.Count;
                if (k != 0)
                {
                    z = Class1.Cerca1(elestanze, num, listView3.SelectedItems[0].SubItems[0].Text);
                }

                label14.Text = elestanze[z].numero.ToString();
                label16.Text= elestanze[z].costo.ToString();
                textBox1.Enabled = true;
            }
            catch
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label19.Text = (int.Parse(textBox1.Text) * int.Parse(label16.Text)).ToString();
            }
            catch 
            {
                if(textBox1.Text!="")
                {
                    MessageBox.Show("Non hai inserito un numero");
                    textBox1.Clear();
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int z = default;
            int k = listView3.SelectedIndices.Count;
            if (k != 0)
            {
                z = Class1.Cerca1(elestanze, num, listView3.SelectedItems[0].SubItems[0].Text);
            }

            elestanze[z].stato = false;
            MessageBox.Show("Stanza prenotata");
            string appoggio = default;
            int x = default(int);
            listView3.Items.Clear();
            
            while (x < num)
            {
                if (elestanze[x].stato == true)
                {
                    appoggio = "Libera";
                }
                if (elestanze[x].stato == false)
                {
                    appoggio = "Occupata";
                }
                if (elestanze[x].stato==true)
                {
                    var row = new string[] { elestanze[x].numero.ToString(), elestanze[x].posti.ToString(), elestanze[x].costo.ToString(), appoggio };
                    var listrow = new ListViewItem(row);
                    listView3.Items.Add(listrow);
                }
                x = x + 1;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
