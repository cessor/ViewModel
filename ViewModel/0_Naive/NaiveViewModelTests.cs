using NUnit.Framework;

namespace Naive
{
    [TestFixture]
    public class NaiveViewModelTests
    {
        [Test]
        public void ShouldInstantiateAViewModelWithoutNotification()
        {
            bool notified = false;

            var viewModel = new NaiveViewModel();
            viewModel.PropertyChanged += (s, e) => notified = true;

            Assert.That(notified, Is.False);
            Assert.That(viewModel.Label, Is.EqualTo(""));
        }

        [Test]
        public void ShouldNotifyMeAboutTheChangeOfValue()
        {
            // Arrange
            bool notified = false;

            // System under Test
            var viewModel = new NaiveViewModel();
            viewModel.PropertyChanged += (s, e) => notified = true;

            // Act
            viewModel.Label = "Sulaco";

            // Assert
            Assert.That(notified, Is.True);
            Assert.That(viewModel.Label, Is.EqualTo("Sulaco"));
        }
    }
}