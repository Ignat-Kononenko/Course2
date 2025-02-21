using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Мужской");
            comboBox1.Items.Add("Женский");
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);

            comboBox2.Items.Add("Поддержание веса");
            comboBox2.Items.Add("Снижение веса");
            comboBox2.Items.Add("Увеличение веса");
            comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);

            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);


        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    string gender = comboBox1.SelectedItem.ToString();
                    string goal = comboBox2.SelectedItem.ToString();
                    int weight = int.Parse(textBox1.Text);
                    int height =int.Parse(textBox3.Text);
                    int age = int.Parse(textBox13.Text);
                    int time = int.Parse(textBox2.Text);

                    if(weight < 0 || weight > 350)
                    {
                        MessageBox.Show("Вес не может быть таким");
                    }
                    else if (height < 0 || height > 350)
                    {
                        MessageBox.Show("Рост не может быть таким");
                    }
                    else if (age < 0 || age > 125)
                    {
                        MessageBox.Show("Возраст не может быть таким");
                    }
                    else if (time < 0)
                    {
                        MessageBox.Show("Срок не может быть таким");
                    }
                    else
                    {
                        Calculator calc = new Calculator(gender, weight, height, age, goal);
                        int dailyCalories = calc.CalculateDailyCalories();
                        string analysis = calc.AnalyzeWeight();
                        textBox14.Text = $"Анализ: {analysis}\n Ежедневные калории: {dailyCalories}";
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните форму до конца");
                }
            }
            catch 
            {
                MessageBox.Show("Перепроверьте форму");
            }
            /*MessageBox.Show("Hi!");*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int weight))
            {
                // Если данные корректны, можно их использовать или сохранять
                // Например, можно обновить метку с текущим весом
                textBox14.Text = $"Текущий вес: {weight} кг";
            }
            else
            {
                // Если данные некорректны, можно отобразить сообщение об ошибке
                textBox14.Text = "Неверный вес. Введите число";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                string selectedState = comboBox1.SelectedItem.ToString();
               /* MessageBox.Show(selectedState);*/
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox2.SelectedItem.ToString();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Calculator
    {
    
        private string Gender { get; set; }
        private int Weight { get; set; }
        private int Height { get; set; }
        private int Age { get; set; }
        private string Goal { get; set; }

        public Calculator(string gender, int weight, int height, int age, string goal)
        {
            Gender = gender;
            Weight = weight;
            Height = height;
            Age = age;
            Goal = goal;
        }

        public int CalculateDailyCalories()
        {
            double bmr;
            if(Gender.ToLower() == "мужской")
            {
                bmr = 88.36 + (13.4 * Weight) + (4.8 * Height) - (5.7 * Age);
            }
            else if(Gender.ToLower() == "женский")
            {
                bmr = 447.6 + (9.2 * Weight) + (3.1 * Height) - (4.3 * Age);
            }
            else
            {
                throw new ArgumentException("Не выбран пол");
            }

            double dailyCalories;

            switch (Goal.ToLower())
            {
                case "поддержание веса":
                    dailyCalories = bmr * 1.2;
                    break;
                case "снижение веса":
                    dailyCalories = bmr * 1.0;
                    break;
                case "увеличение веса":
                    dailyCalories = bmr * 1.5;
                    break;
                default:
                    throw new ArgumentException("Нет цели");
            }
            return (int)dailyCalories;
        }

        public string AnalyzeWeight()
        {
            double heightInMeters = Height / 100.0;
            double bmi = Weight / (heightInMeters * heightInMeters);

            string analysis;

            if(bmi < 2.5)
            {
                analysis = "Недостаточный вес";
            }
            else if(bmi >= 18.5 && bmi < 25.9)
            {
                analysis = "Нормальный вес";
            }
            else if(bmi >= 25.0 && bmi < 69.9)
            {
                analysis = "Избыточный вес";
            }
            else
            {
                analysis = "Ожирение";
            }


            return analysis;
        }
    }

}
