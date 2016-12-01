using SimpleExpressionEvaluator;
using System;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CalculatorDemoApp.Behaviors {

    class CalculatorBehavior : Behavior<TextBox> {

        private static readonly ExpressionEvaluator _evaluator = new ExpressionEvaluator();

        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.LostFocus += Evaluate;
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            this.AssociatedObject.LostFocus -= Evaluate;
        }

        private void Evaluate(object sender, EventArgs e) {
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
