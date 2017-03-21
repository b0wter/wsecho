Goal
====
wsecho gives you a way to send one-time messages. It will connect to the server, send the message and then disconnect. Thus, it is very easy to use in scripts of any kind.

Usage
=====
To run the program you need to supply two parameters:

    -h hostname, in the form: ws://localhost:4096
    -m message that will be sent

To use double quotes in the message you either have to escape them (making \" out of ") or use single quotes and supply the _-q_ option which will replace all single quotes with double quotes before sending the message.

A simple example might look like this:

    ./wsecho -h ws://localhost:4096 -m "{ 'Id': 'myMessageId', 'Command': 'startService' }" -q
