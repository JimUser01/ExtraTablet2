using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Extra_Tablet2.Effects
{

    /// <summary>
    /// Tint image effect
    /// </summary>
    public class TintImageEffect : RoutingEffect
    {
        /// <summary>
        /// Tint color
        /// </summary>
        public Color TintColor { get; set; }
        public TintImageEffect() : base($"{Constants.ProjectName}.{nameof(TintImageEffect)}")
        {
        }
    }
}
