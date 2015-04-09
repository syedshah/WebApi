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
    public class LocalRepositoryTests
    {
        private TransactionScope _transactionScope;
        private LocalityRepository _localityRepository;
        private WelshLocalityRepository _welshLocalityRepository;

        [SetUp]
        public void Setup()
        {
            this._transactionScope = new TransactionScope();
            this._localityRepository = new LocalityRepository(ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString);
            this._welshLocalityRepository =
                new WelshLocalityRepository(ConfigurationManager.ConnectionStrings["PAFContext"].ConnectionString);
        }

        [TearDown]
        public void TearDown()
        {
            this._transactionScope.Dispose();
        }

        [Test]
        public void GivenEnglandOutcodeAndIncode_WhenIAskForTheEnglandLocality_IGetTheLocality()
        {
            var result = this._localityRepository.GetLocality("RM9", "6BF");
            result.Should().NotBeNull();
            result.PostTown.Should().Be("DAGENHAM");
        }

        [Test]
        public void GivenWelshOutcodeAndIncode_WhenIAskForWelshLocality_IGetTheLocality()
        {
            var result = _welshLocalityRepository.GetWelshLocality("CF10", "3NP");
            result.Should().NotBeNull();
            result.WelshLocalityID.Should().BeGreaterOrEqualTo(1);
        }

    }
}
