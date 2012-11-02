using NUnit.Framework;

namespace Improved
{
    [TestFixture]
    public class ImprovedViewModelTests
    {
        [Test]
        public void ShouldInstantiateAViewModelWithoutNotification()
        {
            bool notified = false;

            var viewModel = new ImprovedViewModel();
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
            var viewModel = new ImprovedViewModel();
            viewModel.PropertyChanged += (s, e) => notified = true;

            // Act
            viewModel.Label = "Nostromo";

            // Assert
            Assert.That(notified, Is.True);
            Assert.That(viewModel.Label, Is.EqualTo("Nostromo"));
        }

        [Test]
        public void ShouldNotNotifyIfTheValueHasntActuallyChanged()
        {
            // Arrange
            bool notified = false;

            // System under Test
            var viewModel = new ImprovedViewModel { Label = "Nostromo" };
            viewModel.PropertyChanged += (s, e) => notified = true;
            
            // Act
            viewModel.Label = "Nostromo";

            // Assert
            Assert.That(notified, Is.False);
            Assert.That(viewModel.Label, Is.EqualTo("Nostromo"));
        } 
    }
}