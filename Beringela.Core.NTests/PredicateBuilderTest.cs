﻿using System;
using System.Collections.Generic;
using System.Linq;
using Beringela.Core.Entities;
using Beringela.Core.NTests.Entities;
using NUnit.Framework;

namespace Beringela.Core.NTests
{
    public class PredicateBuilderTest
    {
        [Test]
        public void FilterOnSingleTextual()
        {

            Func<TestEntity, bool> predicate = PredicateBuilder.TextualSearch<TestEntity>("Match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "AnotherMatch"},
                new TestEntity() {Summary = "NotFound"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(2, filteredResults.Count());
        }

        [Test]
        public void GetTextualSearchPredicateIgnoreCaseByDefault()
        {

            Func<TestEntity, bool> predicate = PredicateBuilder.TextualSearch<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "AnotherMatch"},
                new TestEntity() {Summary = "NotFound"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(2, filteredResults.Count());
        }

        [Test]
        public void GetTextualSearchPredicateMultiField()
        {

            Func<TestEntity, bool> predicate = PredicateBuilder.TextualSearch<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match", Description = "NotFound"},
                new TestEntity() {Summary = "AnotherMatch", Description = "NotFound"},
                new TestEntity() {Summary = "NotFound", Description = "Match"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(3, filteredResults.Count());
        }

        [Test]
        public void GetTextualSearchPredicateMultiFieldWithNullField()
        {
            Func<TestEntity, bool> predicate = PredicateBuilder.TextualSearch<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "AnotherMatch", Description = "NotFound"},
                new TestEntity() {Summary = "NotFound", Description = "Match"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(3, filteredResults.Count());
        }

        [Test]
        public void GetTextualSearchPredicateMultiFieldWithoutIgnoreCaseField()
        {
            Func<TestEntity, bool> predicate = PredicateBuilder.TextualSearch<TestEntity>("match");

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "NotFound", Description = "AnotherMatch"},
                new TestEntity() {Summary = "NotFound", Description = "NotFound" , CaseSensitive = "Match"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(2, filteredResults.Count());
        }

        [Test]
        public void GetTextualSearchPredicateWithNullSearch()
        {
            Func<TestEntity, bool> predicate = PredicateBuilder.TextualSearch<TestEntity>(null);

            var list = new List<TestEntity>
            {
                new TestEntity() {Summary = "Match"},
                new TestEntity() {Summary = "NotFound", Description = "AnotherMatch"},
                new TestEntity() {Summary = "NotFound", Description = "NotFound" , CaseSensitive = "Match"}
            };

            var filteredResults = list.Where(predicate);

            Assert.AreEqual(3, filteredResults.Count());
        }
    }
}
