Goal
====
The goal of this project is to give a small tool that easily allows the user to send Websocket messages to a given host.

Usage
=====
The program needs exactly two parameters:

    -h url (e.g ws://localhost:2048)
    -m "this is an example message"

The message can only contain escaped quotation marks:

    \"

instead of:

    "

You can also use single quotes inside the double quoted string. They will automatically be replaced if you pass the

    -q

parameter.
