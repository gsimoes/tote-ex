var prompt = require('prompt');

function nextCommand() {
    prompt.get(['command'], function (err, result) {
        console.log('command: ' + result.command);

        var command = result.command;
        if (command === 'done') {
            console.log('We are done.');

            return;
        }

        nextCommand();
    });
}

nextCommand();