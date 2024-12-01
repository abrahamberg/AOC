using System;

namespace AdventOfCode.Infrastructure;
public static class Quotes
{
    public static string GetRandomQuote()
    {
        string[] starWarsQuotes = {
        "'Never tell me the odds!' - Han Solo",
        "'Do. Or do not. There is no try.' - Yoda",
        "'Your focus determines your reality.' - Qui-Gon Jinn",
        "'I find your lack of faith disturbing.' - Darth Vader",
        "'In my experience, there is no such thing as luck.' - Obi-Wan Kenobi",
        "'Stay on target.' - Gold Five",
        "'The ability to speak does not make you intelligent.' - Qui-Gon Jinn",
        "'Fear is the path to the dark side. Fear leads to anger, anger leads to hate, hate leads to suffering.' - Yoda",
        "'The greatest teacher, failure is.' - Yoda",
        "'Sometimes we must let go of our pride and do what is requested of us.' - Anakin Skywalker",
        "'Be careful not to choke on your aspirations.' - Darth Vader",
        "'The Force will be with you, always.' - Obi-Wan Kenobi",
        "'Good soldiers follow orders.' - Clone Trooper Motto",
        "'The strongest stars have hearts of kyber.' - Chirrut Îmwe",
        "'Hope is like the sun. If you only believe it when you see it, you'll never make it through the night.' - Leia Organa",
        "'You must unlearn what you have learned.' - Yoda",
        "'Patience you must have, my young Padawan.' - Yoda",
        "'It’s not about lifting rocks. It’s about understanding the Force.' - Luke Skywalker",
        "'We are what they grow beyond. That is the true burden of all masters.' - Yoda",
        "'Difficult to see. Always in motion is the future.' - Yoda",
        "'The time to fight is now.' - Saw Gerrera",
        "'Rebellions are built on hope.' - Jyn Erso",
        "'Many of the truths we cling to depend greatly on our point of view.' - Obi-Wan Kenobi",
        "'Who’s the more foolish? The fool or the fool who follows him?' - Obi-Wan Kenobi",
        "'This is the way.' - The Mandalorian",
        "'Failure, the greatest teacher is.' - Yoda",
        "'I am one with the Force, and the Force is with me.' - Chirrut Îmwe",
        "'Great, kid. Don’t get cocky.' - Han Solo",
        "'Powerful you have become. The dark side I sense in you.' - Yoda",
        "'The greatest gift life has to offer is the opportunity to work hard at work worth doing.' - Qui-Gon Jinn",
        "'Trust the Force.' - Luke Skywalker",
        "'Sometimes you must run before you walk.' - Qui-Gon Jinn",
        "'The Force surrounds you, binds you, and lifts your spirit.' - Yoda",
        "'Use the Force, Luke.' - Obi-Wan Kenobi"
        };

        var rnd = new Random();
        var index = rnd.Next(0, starWarsQuotes.Length);
        return starWarsQuotes[index];
    }
}