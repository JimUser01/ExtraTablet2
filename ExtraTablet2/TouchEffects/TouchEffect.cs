using Xamarin.Forms;

namespace Extra_Tablet2.TouchEffects
{
    /// <summary>
    /// Touch effect
    /// </summary>
    public class TouchEffect : RoutingEffect
    {
        public event TouchActionEventHandler TouchAction;

        public TouchEffect() : base($"{Constants.ProjectName}.{nameof(TouchEffect)}")
        {
        }

        public bool Capture { set; get; }

        public void OnTouchAction(Element element, TouchActionEventArgs args)
        {
            TouchAction?.Invoke(element, args);
        }
    }
}
