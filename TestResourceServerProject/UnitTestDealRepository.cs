using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceServer.Model.Deal;
using ResourceServer.Repositories;
using ResourceServer.Repositories.Memory;
using System;

namespace TestResourceServerProject
{
    [TestClass]
    public class UnitTestDealRepository
    {
        [TestMethod]
        public void CreateDeal_DealIsCreatedRight_DealIsCreated()
        {
            //Arrange
            IDealContext dealContext = new DealContextInMemory();
            DealRepository dealRepository = new DealRepository(dealContext);

            DealDto newDeal = new();

            //Act
            System.Threading.Tasks.Task<Deal>? createddeal = dealRepository.createDeal(newDeal);

            //Assert
            Assert.IsNotNull(createddeal);
        }
    }
}