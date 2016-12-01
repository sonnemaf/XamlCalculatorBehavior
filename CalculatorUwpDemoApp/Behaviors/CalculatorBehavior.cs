using Microsoft.Xaml.Interactivity;
using SimpleExpressionEvaluator;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CalculatorUwpDemoApp.Behaviors {

    class CalculatorBehavior : Behavior<TextBox> {

        private static ExpressionEvaluator _evaluator = new ExpressionEvaluator();

        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.LostFocus += Evaluate;
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            this.AssociatedObject.LostFocus -= Evaluate;
        }

        private void Evaluate(object sender, RoutedEventArgs e) {
            try {
                string txt = this.AssociatedObject.Text;
                if (!string.IsNullOrWhiteSpace(txt)) {
                    var result = _evaluator.Evaluate(txt);
                    this.AssociatedObject.Text = result.ToString();
                }
            } catch { }
        }
    }
}
