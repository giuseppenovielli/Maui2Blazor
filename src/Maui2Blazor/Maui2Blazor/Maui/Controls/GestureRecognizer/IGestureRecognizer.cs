namespace Maui2Blazor.Maui.Controls
{
    public interface IGestureRecognizer
    {
        /// <summary>
        /// Evento sollevato quando si verifica un tap.
        /// </summary>
        event EventHandler Tap;

        /// <summary>
        /// Evento sollevato quando si verifica uno swipe.
        /// </summary>
        event EventHandler<SwipeEventArgs> Swipe;

        /// <summary>
        /// Evento sollevato quando si verifica un pinch.
        /// </summary>
        event EventHandler<PinchEventArgs> Pinch;

        // Puoi aggiungere altri eventi o metodi per gesti come long press, pan, ecc.
    }

    public class SwipeEventArgs : EventArgs
    {
        /// <summary>
        /// Direzione dello swipe.
        /// </summary>
        public SwipeDirection Direction { get; set; }
    }

    public enum SwipeDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    public class PinchEventArgs : EventArgs
    {
        /// <summary>
        /// Fattore di scala ottenuto durante il pinch.
        /// </summary>
        public double Scale { get; set; }
    }


}

