using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DojoCucumber
{
    [Binding]
    public class CenarioEmitirEtiqueta
    {
        private IWebDriver driver;

        [Given(@"que eu estou na pagina do enderecador")]
        public void DadoQueEuEstouNaPaginaDoEnderecador()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://correios.com.br");
            driver.FindElement(By.CssSelector("#content-principais-servicos > ul > li:nth-child(6) > a")).Click();
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > p:nth-child(4) > a:nth-child(1)")).Click(); ;
        }

        [When(@"eu preencher o CEP ""(.*)"" na tela com o nome ""(.*)"" com a promo ""(.*)"" com o numero ""(.*)""")]
        public void QuandoEuPreencherOCEPNaTelaComONomeComComONumero(string cep, string nome, string promo, string numero)
        { 
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > p > span > label > input[type='text']:nth-child(2)")).SendKeys(cep);
            driver.FindElement(By.CssSelector("body")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")));

            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")).SendKeys(cep);
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(5) > label > input")).SendKeys(cep);

            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(8) > label > input")).SendKeys(numero);

            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(4) > label > input[type='text']:nth-child(3)")).SendKeys("80002900");

            driver.FindElement(By.CssSelector("body")).Click();

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(9) > div > span:nth-child(4) > label > input")));

            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(6) > label > input")).SendKeys("Blá Blá Blá");
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(7) > label > input")).SendKeys("Promo");
            driver.FindElement(By.CssSelector("body > div.back > div.tabs > div:nth-child(2) > div > div > div.column2 > div.content > div.ctrlcontent > form > div:nth-child(11) > div > span:nth-child(10) > label > input")).SendKeys("100");

        }

        [When(@"clicar no botao")]
        public void QuandoClicarNoBotao()
        {
            driver.FindElement(By.CssSelector("#btGerarEtiquetas")).Click();
        }

        [Then(@"a etiqueta deve ser emitida")]
        public void EntaoAEtiquetaDeveSerEmitida()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
