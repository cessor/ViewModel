using NUnit.Framework;

namespace Expressions
{
    [TestFixture]
    public class ExpressionViewModelTests
    {
        [Test]
        public void ShouldInstantiateAViewModelWithoutNotification()
        {
            bool notified = false;

            var viewModel = new ExpressionViewModel();
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
            var viewModel = new ExpressionViewModel();
            viewModel.PropertyChanged += (s, e) => notified = true;

            // Act
            viewModel.Label = "Sulaco";

            // Assert
            Assert.That(notified, Is.True);
            Assert.That(viewModel.Label, Is.EqualTo("Sulaco"));
        }

        [Test]
        public void ShouldNotNotifyIfTheValueHasntActuallyChanged()
        {
            // Arrange
            bool notified = false;

            // System under Test
            var viewModel = new ExpressionViewModel { Label = "Sulaco" };
            viewModel.PropertyChanged += (s, e) => notified = true;
            
            // Act
            viewModel.Label = "Sulaco";

            // Assert
            Assert.That(notified, Is.False);
            Assert.That(viewModel.Label, Is.EqualTo("Sulaco"));
        } 
    }
}