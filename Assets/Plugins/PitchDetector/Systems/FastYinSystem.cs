using UnityEngine;
using Unity.Entities;
using FinerGames.PitchDetector;

public class FastYinSystem : ComponentSystem
{
    EntityQuery pitchDetectors;

    FastYin fastYin;

    protected override void OnCreate()
    {
        base.OnCreate();

        var query = new EntityQueryDesc()
        {
            All = new ComponentType[] { typeof(PitchDetector), },
        };
        pitchDetectors = GetEntityQuery(query);

        fastYin = new FastYin(44100, 1024);
    }
    protected override void OnUpdate()
    {
        Entities.ForEach((PitchDetector detector) =>
        {
            if (detector.Source == null)
                return;

            if (detector.Source.clip == null)
                return;

            var buffer = new float[1024];
            detector.Source.GetOutputData(buffer, 0);

            //TODO -> jobify + burst
            var result = fastYin.getPitch(buffer);
            
            var pitch = result.getPitch();
            var midiNote = 0;
            var midiCents = 0;

            Pitch.PitchDsp.PitchToMidiNote(pitch, out midiNote, out midiCents);

            detector.Pitch = pitch;
            detector.MidiNote = midiNote;
            detector.MidiCents = midiCents;
        //}, pitchDetectors);
        });
    }

}
