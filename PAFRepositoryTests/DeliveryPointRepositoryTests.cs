using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Entities;
using FluentAssertions;
using NUnit.Framework;
using PAFRepository.Repositories;

namespace PAFRepositoryTests
{
    [Category("Integration")]
    [TestFixture]
    public class DeliveryPointRepositoryTests
    {
        private TransactionScope _transactionScope;
        private DeliveryPointRepository _deliveryPointsRepository;
        private WelshDeliveryPointRepository _welshDeliveryPointsRepository;

        [SetUp]
        public void Setup()
        {
            this._transactionScope = new TransactionScope();
            this._deliveryPointsRepository =
                new DeliveryPointRepository(ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString);
            this._welshDeliveryPointsRepository =
                new WelshDeliveryPointRepository(ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString);
        }

        [Test]
        public void GivenEnglandOutcodeAndIncode_WhenIAskForTheDeliveryPoints_IGetListOfDeliveryPoints()
        {
            var result = _deliveryPointsRepository.GetDeliveryPoints("IG1", "3AJ");
            result.Should().NotBeNullOrEmpty();
            result.Count().Should().BeGreaterOrEqualTo(1);
            result.Should().BeOfType<List<DeliveryPoint>>();
        }

        [Test]
        public void GivenWelshOutcodeAndIncode_WhenIAskForTheDeliveryPoints_IGetListOfDeliveryPoints()
        {
            var result = this._welshDeliveryPointsRepository.GetWelshDeliveryPoints("CF10", "5BF");
            result.Should().NotBeNullOrEmpty();
            result.Count().Should().BeGreaterOrEqualTo(1);
            result.Should().BeOfType<List<WelshDeliveryPoint>>();
        }
    }
}
