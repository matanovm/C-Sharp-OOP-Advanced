<h1>Exercises: SOLID</h1>
1.	Logger
Write a logging library for logging messages.
<h2>Library Architecture</h2>
<ul>
<li>•	Layouts - define the format in which messages should be appended (e.g. SimpleLayout displays logs in the format "< date-time > - < report level > - < message >")</li>
<li>•	Appenders - responsible for appending the messages somewhere (e.g. Console, File, etc.)</li>
<li>•	Loggers - hold methods for various kinds of logging (warnings, errors, info, etc.)</li>
</ul>

Whenever a logger is told to log something, it calls all of its appenders and tells them to append the message. In turn, the appenders append the message (e.g. to the console or a file) according to the layout they have.
>Requirements

Your library should correctly follow all of the SOLID principles:
<ul>
<li>•	Single Responsibility Principle - no class or method should do more than one thing at once</li>
<li>•	Open-Closed Principle - the library should be open for extension (i.e. its user should be able to create his own layouts/appenders/loggers)</li>
<li>•	Liskov Substitution Principle - children classes should not break the behavior of their parent</li>
<li>•	Interface Segregation Principle - the library should provide simple interfaces for the client to implement</li>
<li>•	Dependency Inversion - no class/method should directly depend on concretions (only on abstractions)</li>
</ul>

Avoid code repetition. Name everything accordingly.

>Implementations

The library should provide the following ready classes for the client:

<ul>
<li>•	SimpleLayout - defines the format "< date-time > - < report level < - < message >"</li>
<li>•	ConsoleAppender - appends a log to the console, using the provided layout</li>
<li>•	FileAppender - appends a log to a file, using the provided layout</li>
<li>•	LogFile - a custom file class, which logs messages in a string builder, using a method Write(). It should have a getter for its size, which is the sum of the ascii codes of all alphabet characters it contains (e.g. a-z and A-Z)</li>
<li>•	Logger - a logger class, which is used to log messages. Calls each of its appenders when something needs to be logged</li>
</ul>

>Extensibility

The end-user should be able to add his own layouts/appenders/loggers and use them. For example, he should be able to create his own XmlLayout and make the appenders use it, without directly editing the library source code.

>Report Threshold

Implement a report level threshold in all appenders. The appender should append only messages with report level above or equal to its report level threshold (by default all messages are appended). The report level is in the order Info > Warning > Error > Critical > Fatal. Only messages from error and above are appended.

> LogFile

A file should write all messages internally and it should keep information about its size.

Size of a file is calculated by summing ASCII codes of all alphabet characters (a-Z). For example, a file appender with simple layout and a single message "3/31/2015 5:33:07 PM - ERROR - Error parsing request" has size 2606 (including all characters in PM, ERROR, Error, parsing, request). In case of Xml layout, the file would have size 6632, because of the extra characters within the tags.

>Command Interpreter

Implement a Command Interpreter, which reads all appenders that a Logger will have and input messages from the console. Every message should be evaluated by all the appenders and logged, if they meet the report level. Console appenders should write directly on the console. File appenders write (save) the messages, but do not print them.

> Input

On the first line, you will get N - the number of appenders. On the next N lines, you will get information about the appenders in one of the formats below:

*	"< appender type >< layout type >< REPORT LEVEL >"
* "< apender type >< layout type >"

If no report level is provided, the appender should be set to record all messages.
Next, until you get the "END" command you will receive messages containing report level, time and message separated by pipe "|":

* "< REPORT LEVEL >|< time >|< message >"

>Output

Console appenders should print directly at the console in the layout they are provided:

*	Simple layout example - "3/31/2015 5:33:07 PM - ERROR - Error parsing request"
*	Xml layout example (date, level and message tags are indented by 1 tabulation):
*
      <log>
            <date>3/31/2015 5:33:07 PM</date>
            <level>ERROR</level>
            <message>Error parsing request</message>
      </log>

After the "END" command, you should print Logger info, which includes statistics about every appender (its type, layout, report level, messages appended and file size for file appenders):

"Logger info

Appender type: < appender type >, Layout type: < layout type>, Report level: < REPORT LEVEL >, Messages appended: < count >, File size < size >"

<h3>Example</h3>

> Input

    2
    ConsoleAppender SimpleLayout CRITICAL
    FileAppender XmlLayout
    INFO|3/26/2015 2:08:11 PM|Everything seems fine
    WARNING|3/26/2015 2:22:13 PM|Warning: ping is too high - disconnect imminent
    ERROR|3/26/2015 2:32:44 PM|Error parsing request
    CRITICAL|3/26/2015 2:38:01 PM|No connection string found in App.config
    FATAL|3/26/2015 2:39:19 PM|mscorlib.dll does not respond
    END

> Output

    3/26/2015 2:38:01 PM - CRITICAL - No connection string found in App.config
    3/26/2015 2:39:19 PM - FATAL - mscorlib.dll does not respond
    Logger info
    Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2
    Appender type: FileAppender, Layout type: XmlLayout, Report level: INFO, Messages appended: 5, File size: 37526
