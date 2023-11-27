
namespace LSystemsDemo
{
    internal class MusicalEvent
    {
        public float startTime;
        public float duration;
        public float pitch;
        public float pan;
        public float amplitude = 2500f;
        public string wavetable = "ampenv";

        public MusicalEvent(float startTime, float duration, float pitch, float pan)
        {
            this.startTime = startTime;
            this.duration = duration;
            this.pitch = pitch;
            this.pan = pan;
        }

        public string outputRTCMix()
        {
            if(pitch == 0)
            {
                amplitude = 0;
            }

            string output = "WAVETABLE(" + startTime + ", " + duration + ", " + amplitude + ", " + pitch + ", " + pan + ", " + wavetable + ")";
            return output;
        }

    }
}