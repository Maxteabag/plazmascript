using System.Xml.Linq;

namespace PlazmaScript.Core
{
    //TODO: Verify actual XML structure for Voice objects
    public class Voice : LinkedObject
    {
        public Voice()
        {
            Uid = RandomGenerator.RandomString(10);
            PB2Map.MapObjects.Add(this);
        }

        /// <summary>
        /// Create Voice object and save it as a variable
        /// </summary>
        /// <param name="variable">Variable to store the Voice object</param>
        public static TriggerAction CreateVoice(Variable variable)
        {
            return new TriggerAction
            {
                ParameterA = variable.Name,
                ParameterB = "-1",
                TriggerId = 198
            };
        }

        /// <summary>
        /// Set volume for this Voice object
        /// </summary>
        /// <param name="volume">Volume level</param>
        public TriggerAction SetVolume(double volume)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = volume.ToString(),
                TriggerId = 199
            };
        }

        /// <summary>
        /// Set pitch for this Voice object
        /// </summary>
        /// <param name="pitch">Pitch value</param>
        public TriggerAction SetPitch(double pitch)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = pitch.ToString(),
                TriggerId = 200
            };
        }

        /// <summary>
        /// Set voice model for this Voice object
        /// </summary>
        /// <param name="model">Voice model identifier</param>
        public TriggerAction SetVoiceModel(string model)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = model,
                TriggerId = 201
            };
        }

        /// <summary>
        /// Speak text with this Voice object
        /// </summary>
        /// <param name="text">Text to speak</param>
        public TriggerAction SpeakText(string text)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = text,
                TriggerId = 202
            };
        }

        /// <summary>
        /// Speak text-value of a variable with this Voice object
        /// </summary>
        /// <param name="textVariable">Variable containing text to speak</param>
        public TriggerAction SpeakText(Variable textVariable)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = textVariable.Name,
                TriggerId = 203
            };
        }

        /// <summary>
        /// Set rate for this Voice object
        /// </summary>
        /// <param name="rate">Voice rate value</param>
        public TriggerAction SetRate(double rate)
        {
            return new TriggerAction
            {
                ParameterA = Uid,
                ParameterB = rate.ToString(),
                TriggerId = 244
            };
        }

        public override XElement CreateXmlElement()
        {
            var voiceElement = new XElement("voice");
            voiceElement.SetAttributeValue("uid", Uid);
            return voiceElement;
        }
    }
}