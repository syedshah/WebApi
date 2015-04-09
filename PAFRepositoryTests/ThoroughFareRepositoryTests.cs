using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using NUnit.Framework;
using PAFRepository.Repositories;

namespace PAFRepositoryTests
{
    [Category("Integration")]
    [TestFixture]
    public class ThoroughFareRepositoryTests
    {
        private TransactionScope _transactionScope;
        private ThoroughFareRepository _thoroughFareRepository;
        private WelshThoroughFareRepository _welshThoroughFareRepository;

        [SetUp]
        public void Setup()
        {
            this._transactionScope = new TransactionScope();
            this._thoroughFareRepository =
                new ThoroughFareRepository(ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString);
            this._welshThoroughFareRepository =
                new WelshThoroughFareRepository(ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString);
        }

        [Test]
        public void GivenEnglandOutCodeAndInCode_WhenIWantEnglandThoroughFare_IGetTheThoroughFare()
        {
            var result = _thoroughFareRepository.GetThoroughFare("RM9", "6BF");

            result.Should().NotBeNull();
            result.ThoroughFareName.Should().Be("CHOATS");
        }

        [Test]
        public void GivenWelshOutCodeAndInCode_WhenIWantWelshThoroughFare_IGetTheThroughFare()
        {
            var result = _welshThoroughFareRepository.GetWelshThoroughFare("CF10", "3NP");

            result.Should().NotBeNull();
        }
    }
}
