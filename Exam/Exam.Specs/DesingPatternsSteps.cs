using System;
using System.Collections.Generic;
using System.Linq;
using Exam.PatronIterator;
using Exam.Specs.Models;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Exam.Specs
{
    [Binding]
    internal class DesingPatternsSteps
    {
        private AdditionCreator sum = new AdditionCreator();
        private SubtractionCreator res = new SubtractionCreator();
        private MultiplicationCreator mult = new MultiplicationCreator();
        public List<Results> listResults = new List<Results>();
        private IEnumerable<DataFormat> _format;
        Observer observer = new Observer();
        public Subject Subject;

        public int SumFirstElement;
        public int SumSecondElement;
        public int RestFirstElement;
        public int RestSecondElement;
        public int MulFirstElement;
        public int MulSecondElement;
        public int FactorySumResult;
        public int FactoryRestResult;
        public int FactoryMultResult;
        
        public int average;


        Collection collection = new Collection();

        [Given(@"I have the following data from a file")]
        public void GivenIHaveTheFollowingDataFromAFile(IEnumerable<DataFormat> table)
        {
            _format = table;
        }

        [When(@"I call Factory Method")]
        public void WhenICallFactoryMethod()
        {
            SumFirstElement = _format.First(x => x.Name.Equals("Suma") && x.FirstElement == 1).FirstElement;
            SumSecondElement = _format.First(x => x.Name.Equals("Suma") && x.SecondElement == 3).SecondElement;
            RestFirstElement = _format.First(x => x.Name.Equals("Resta") && x.FirstElement == 5).FirstElement;
            RestSecondElement = _format.First(x => x.Name.Equals("Resta") && x.SecondElement == 6).SecondElement;
            MulFirstElement = _format.First(x => x.Name.Equals("Multiplicacion") && x.FirstElement == 4).FirstElement;
            MulSecondElement = _format.First(x => x.Name.Equals("Multiplicacion") && x.SecondElement == 3).SecondElement;
            FactorySumResult = sum.FactoryMethod().Execute(SumFirstElement, SumSecondElement);
            FactoryRestResult = res.FactoryMethod().Execute(RestFirstElement, RestSecondElement);
            FactoryMultResult = mult.FactoryMethod().Execute(MulFirstElement, MulSecondElement);

        }

        [When(@"I call Iterator Method")]
        public void WhenICallIteratorMethod()
        {

            collection[0] = sum.FactoryMethod();
            collection[1] = res.FactoryMethod();
            collection[2] = mult.FactoryMethod();
        }

        [When(@"I call Observer Method")]
        public void WhenICallObserverMethod()
        {
            listResults = new List<Results>
            {
                new Results {NameClass = "Addition", ResultOfClass = sum.FactoryMethod().Execute(1, 3)},
                new Results {NameClass = "Subtraction", ResultOfClass = res.FactoryMethod().Execute(5, 6)},
                new Results {NameClass = "Multiplication", ResultOfClass = mult.FactoryMethod().Execute(4, 3)}
            };

            Subject = new Subject(observer);
            average = Subject.CalculateAverage(listResults);
            Subject.NotifyChange(average);
        }


        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(IEnumerable<ResultModel> table)
        {

            int sumExpected = table.ElementAt(0).FactoryResult;
            int restExpected = table.ElementAt(1).FactoryResult;
            int mulExpected = table.ElementAt(2).FactoryResult;
            Assert.AreEqual(sumExpected, Convert.ToInt32(FactorySumResult));
            Assert.AreEqual(restExpected, FactoryRestResult);
            Assert.AreEqual(mulExpected, FactoryMultResult);

            var iter = collection.CreateIterator();
            var temp = iter.First();
            int ResultCount = 0;
            while (temp != null)
            {

                var result = temp.Execute(2, 1);
                Assert.AreEqual(table.ElementAt(ResultCount).IteratorResult, result);
                ResultCount++;
                temp = iter.Next();
            }

            Assert.AreEqual(table.ElementAt(0).ObserverResult, average);
            Assert.AreEqual(table.ElementAt(1).ObserverResult, observer.GetAverage());

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


