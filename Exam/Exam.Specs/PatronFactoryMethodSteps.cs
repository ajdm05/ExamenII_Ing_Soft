using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Exam.Specs
{
    [Binding]
    internal class PatronFactoryMethodSteps
    {
        private AdditionCreator sum = new AdditionCreator();
        private SubtractionCreator res = new SubtractionCreator();
        private MultiplicationCreator mult = new MultiplicationCreator();
        private IEnumerable<DataFormat> format;
        public int SumFirstElement ;
        public int SumSecondElement;
        public int RestFirstElement ;
        public int RestSecondElement;
        public int MulFirstElement  ;
        public int MulSecondElement ;

        [Given(@"I have the following data from a file")]
        public void GivenIHaveTheFollowingDataFromAFile(IEnumerable<DataFormat> table)
        {
            format = table;
        }

        [When(@"I call Factory Method")]
        public void WhenICallFactoryMethod()
        {
            SumFirstElement =  format.First(x => x.Name.Equals("Suma") && x.FirstElement==1).FirstElement;
            SumSecondElement = format.First(x => x.Name.Equals("Suma") && x.SecondElement==3).SecondElement;
            RestFirstElement = format.First(x => x.Name.Equals("Resta") && x.FirstElement == 5).FirstElement;
            RestSecondElement =format.First(x => x.Name.Equals("Resta") && x.SecondElement == 6).SecondElement;
            MulFirstElement = format.First(x => x.Name.Equals("Multiplicacion") && x.FirstElement == 4).FirstElement;
            MulSecondElement = format.First(x => x.Name.Equals("Multiplicacion") && x.SecondElement == 3).SecondElement;
            

        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(IEnumerable<ResultModel> table)
        {
           var sumResult = sum.FactoryMethod().Execute(SumFirstElement,SumSecondElement);
           var restResult=  res.FactoryMethod().Execute(RestFirstElement,RestSecondElement);
           var multResult = mult.FactoryMethod().Execute(MulFirstElement,MulSecondElement);

            int sumExpected = table.First(x => x.Result == 4).Result;
            int restExpected = table.First(x => x.Result == -1).Result;
            int mulExpected = table.First(x => x.Result == 12).Result;
            Assert.AreEqual(sumExpected, Convert.ToInt32( sumResult));
            Assert.AreEqual(restExpected, restResult);
            Assert.AreEqual(mulExpected,multResult);

        }

        [StepArgumentTransformation]
        public IEnumerable<DataFormat> ConvertDataFormat(Table table)
        {
            return table.CreateSet<DataFormat>();

        }

        [StepArgumentTransformation]
        public IEnumerable<ResultModel> ConvertResultModel(Table table)
        {
            return table.CreateSet<ResultModel>();

        }
    }
}


