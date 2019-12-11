using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo
{
    public partial class Form1 : Form
    {
        IWebDriver Browser;
        
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            Browser.Navigate().GoToUrl("http://google.com");

            IWebElement SearchInput = Browser.FindElement(By.Name("q"));
            SearchInput.SendKeys("Как вырастить гомункула?" + OpenQA.Selenium.Keys.Enter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Browser.Quit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("https://www.avito.ru/kirovskaya_oblast_kirov/kvartiry");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            IWebElement element;
            //Поиск по id элемента
            //element= Browser.FindElement(By.Id("text"));
            //element.SendKeys("Tect");

            //Поиск по классу элемента
            //element = Browser.FindElement(By.ClassName("home-logo__default"));
            //element.Click();

            //Поиск по тексту ссылки
            //element = Browser.FindElement(By.LinkText("Картинки"));
            //element.Click();

            //Поиск по частичному тексту ссылки
            element = Browser.FindElement(By.PartialLinkText("ревод"));
            element.Click();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //List<IWebElement> News = Browser.FindElements(By.XPath(".//*[@id='catalog']/div[5]/div[1]/div[4]/div[2]/div[3]/div/div[2]/div/div[2]/div[1]/div[1]/h3/a/span")).ToList();
            //List<IWebElement> News = Browser.FindElements(By.XPath("html/body/div[5]/div[1]/div[4]/div[2]/div[3]/div/div[2]/div/div[2]/div[1]/div[1]/h3/a/span")).ToList();


            List<IWebElement> Name = Browser.FindElements(By.XPath("//a[@class='item-description-title-link']/span")).ToList();
            List<IWebElement> Price = Browser.FindElements(By.XPath("//span[@itemprop='price']")).ToList();
            List<IWebElement> Adress = Browser.FindElements(By.XPath("//span[@class='item-address__string']")).ToList();

           // List<IWebElement> Price = Browser.FindElements(By.XPath("//div[@class='item_table-description']/div[1]/span[2]]")).ToList();
          //  List<IWebElement> Name = Browser.FindElements(By.XPath("//div[@class='description item_table-description']/div[1]/h3/a/span")).ToList();
           // List<IWebElement> Adress = Browser.FindElements(By.XPath("//div[@class='description item_table-description']/div[2]/div[1]/span[3]")).ToList();
            for (int i = 0; i < Name.Count; i++)
            {
                    
                
                //Выведение новости
                //textBox1.AppendText(Price[i].Text + "\r\n");
              //  textBox1.AppendText(Name[i].Text + "\r\n");
                dataGridView1.Rows.Add(Name[i].Text, Price[i].Text, Adress[i].Text);
               
                
               

               // String s = News[i].Text;

              /*  if (s.StartsWith("Москва"))
                {
                    textBox1.AppendText("Новость № " + (i + 1).ToString() + " Начинается с текста 'Москва'");

                }

                if (s.EndsWith("границы"))
                {
                    textBox1.AppendText("Новость № " + (i + 1).ToString() + " заканчивается на слово 'границы'");

                }

                if (s.Contains("МИД"))
                {
                    textBox1.AppendText("Новость № " + (i + 1).ToString() + " заканчивается на слово 'МИД");
                    News[i].Click();
                    break;
                }*/
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IJavaScriptExecutor jse = Browser as IJavaScriptExecutor;
            jse.ExecuteScript("alert('test');");
        }

        private string FindWindow(String Url)
        {
            String StartWindow = Browser.CurrentWindowHandle;
            String Result = "";

            for (int i = 0; i < Browser.WindowHandles.Count;i++)
            { if (Browser.WindowHandles[i] != StartWindow)
                {
                    Browser.SwitchTo().Window(Browser.WindowHandles[i]);
                    if(Browser.Url.Contains(Url))
                    {
                        Result = Browser.WindowHandles[i];
                        break;
                    }
                }
            }
            Browser.SwitchTo().Window(StartWindow);
            return Result;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            /* Browser.SwitchTo().Window(Browser.WindowHandles[1]);
             System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);

             Browser.SwitchTo().Window(Browser.WindowHandles[0]);
             System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);

             Browser.SwitchTo().Window(Browser.WindowHandles[2]);
             System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);

            String HabrWindow = FindWindow("habr");
            Browser.SwitchTo().Window(HabrWindow);
            System.Windows.Forms.MessageBox.Show(Browser.Title + "\r\n" + Browser.Url);*/

            
        }




       


    }
}
