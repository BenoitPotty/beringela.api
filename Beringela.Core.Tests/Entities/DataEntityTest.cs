using System;
using System.Collections.Generic;
using System.Linq;
using Beringela.Core.Entities;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beringela.Core.Tests.Entities
{
    [TestClass]
    public class DataEntityTest
    {
        private DataEntity entity;

        [TestInitialize]
        public void Setup()
        {
            entity = new TestEntity();
        }

        [TestMethod]
        public void GetAllTextualSearchProperties()
        {
            var properties = DataEntity.GetAllTextualSearchProperties<TestEntity>();
            Assert.AreEqual(2, properties.Count());
        }

        [TestMethod]
        public void FilterOnSingleTextual()
        {

            Func<TestEntity, bool> predicate = DataEntity.GetTextualSearchPredicate<TestEntity>("Match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"}, 
                new TestEntity() {Summary = "AnotherMatch"},
                new TestEntity() {Summary = "NotFound"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(2, filteredResults.Count());
        }

        [TestMethod]
        public void GetTextualSearchPredicateIgnoreCaseByDefault()
        {

            Func<TestEntity, bool> predicate = DataEntity.GetTextualSearchPredicate<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "AnotherMatch"},
                new TestEntity() {Summary = "NotFound"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(2, filteredResults.Count());
        }

        [TestMethod]
        public void GetTextualSearchPredicateMultiField()
        {

            Func<TestEntity, bool> predicate = DataEntity.GetTextualSearchPredicate<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match", Description = "NotFound"},
                new TestEntity() {Summary = "AnotherMatch", Description = "NotFound"},
                new TestEntity() {Summary = "NotFound", Description = "Match"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(3, filteredResults.Count());
        }

        [TestMethod]
        public void GetTextualSearchPredicateMultiFieldWithNullField()
        {
            Func<TestEntity, bool> predicate = DataEntity.GetTextualSearchPredicate<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "AnotherMatch", Description = "NotFound"},
                new TestEntity() {Summary = "NotFound", Description = "Match"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(3, filteredResults.Count());
        }


        //Objective => have a func that returns Func<T, bool> predicate = null
    }
}