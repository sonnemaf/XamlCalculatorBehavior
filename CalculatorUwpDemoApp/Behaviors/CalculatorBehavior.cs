using Microsoft.Xaml.Interactivity;
using SimpleExpressionEvaluator;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CalculatorUwpDemoApp.Behaviors {

    class CalculatorBehavior : Behavior<TextBox> {

        private static readonly ExpressionEvaluator _evaluator =
            new ExpressionEvaluator();

        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.LostFocus += TextBox_LostFocus;
            this.AssociatedObject.HandwritingView.Closed += this.HandwritingView_Closed;
        }

        private void HandwritingView_Closed(HandwritingView sender, HandwritingPanelClosedEventArgs args) {
            Evaluate();
        }


        protected override void OnDetaching() {
            base.OnDetaching();
            this.AssociatedObject.LostFocus -= TextBox_LostFocus;
            this.AssociatedObject.HandwritingView.Closed -= this.HandwritingView_Closed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
            Evaluate();
        }

        private void Evaluate() {
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
