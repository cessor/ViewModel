using NUnit.Framework;

namespace CallerMemberNameViewModel
{
    [TestFixture]
    public class CallerMemberNameViewModelTest
    {
        [Test]
        public void ShouldInstantiateAViewModelWithoutNotification()
        {
            bool notified = false;

            var viewModel = new CallerMemberNameViewModel();
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
            var viewModel = new CallerMemberNameViewModel();
            viewModel.PropertyChanged += (s, e) => notified = true;

            // Act
            viewModel.Label = "LV426";

            // Assert
            Assert.That(notified, Is.True);
            Assert.That(viewModel.Label, Is.EqualTo("LV426"));
        }

        [Test]
        public void ShouldNotNotifyIfTheValueHasntActuallyChanged()
        {
            // Arrange
            bool notified = false;

            // System under Test
            var viewModel = new CallerMemberNameViewModel { Label = "LV426" };
            viewModel.PropertyChanged += (s, e) => notified = true;
            
            // Act
            viewModel.Label = "LV426";

            // Assert
            Assert.That(notified, Is.False);
            Assert.That(viewModel.Label, Is.EqualTo("LV426"));
        } 
    }
}