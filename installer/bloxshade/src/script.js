// wait for element to exist
function waitForElementToExist(elementId, callback) {
    var element = document.getElementById(elementId);
    if (element) {
        callback();
    } else {
        setTimeout(function () {
            waitForElementToExist(elementId, callback);
        }, 100);
    }
}

// wait for content to load
document.addEventListener("DOMContentLoaded", function () {
    // wait for set to exist
    waitForElementToExist("set", function () {
        document.getElementById("set").addEventListener("click", function () {
            var element0 = document.getElementById("con-0");
            var element3 = document.getElementById("con-3");

            element0.classList.remove("show");
            element0.classList.add("hide");

            element3.classList.remove("hide");
            element3.classList.add("show");
        });
    });

    // wait for uwu
    waitForElementToExist("uwu", function () {
        document.getElementById("uwu").addEventListener("click", function () {
            var element0 = document.getElementById("con-0");
            var element3 = document.getElementById("con-3");

            element0.classList.remove("hide");
            element0.classList.add("show");

            element3.classList.remove("show");
            element3.classList.add("hide");
        });
    });

    // wait for install
    waitForElementToExist("install", function () {
        document.getElementById("install").addEventListener("click", function () {
            var element0 = document.getElementById("con-0");
            var element1 = document.getElementById("con-1");

            element0.classList.remove("show");
            element0.classList.add("hide");

            element1.classList.remove("hide");
            element1.classList.add("show");
        });
    });

    // wait for user presets
    waitForElementToExist("userPresets", function () {
        document.getElementById("userPresets").addEventListener("click", function () {
            var element0 = document.getElementById("con-4");
            var element1 = document.getElementById("con-2");

            element0.classList.remove("show");
            element0.classList.add("hide");

            element1.classList.remove("hide");
            element1.classList.add("show");
        });
    });

    // wait for acknowledgements
    waitForElementToExist("acknowledgements", function () {
        document.getElementById("acknowledgements").addEventListener("click", function () {
            var element0 = document.getElementById("con-5");
            var element1 = document.getElementById("con-0");

            element0.classList.remove("show");
            element0.classList.add("hide");

            element1.classList.remove("hide");
            element1.classList.add("show");
        });
    });

    // wait for set-acknowledgements
    waitForElementToExist("set-acknowledgements", function () {
        document.getElementById("set-acknowledgements").addEventListener("click", function () {
            var element0 = document.getElementById("con-0");
            var element1 = document.getElementById("con-5");

            element0.classList.remove("show");
            element0.classList.add("hide");

            element1.classList.remove("hide");
            element1.classList.add("show");
        });
    });

    // wait for nv-uwu
    waitForElementToExist("nv-uwu", function () {
        document.getElementById("nv-uwu").addEventListener("click", function () {
            var element0 = document.getElementById("con-3");
            var element1 = document.getElementById("con-6");

            element0.classList.remove("show");
            element0.classList.add("hide");

            element1.classList.remove("hide");
            element1.classList.add("show");
        });
    });

    // wait for checkbox
    waitForElementToExist("box-0", function () {
        document.getElementById("box-0").checked = true;
    });

    waitForElementToExist("box-1", function () {
        document.getElementById("box-1").checked = true;
    });

    waitForElementToExist("box-2", function () {
        document.getElementById("box-2").checked = true;
    });

    // toggle zoom
    function toggleZoomScreen(event) {
        if (!event.ctrlKey && !event.metaKey) {
            event.preventDefault();

            const zoomStep = 0.1;
            const zoomMin = 0.1;
            const zoomMax = 2;

            let currentZoom = parseFloat(document.body.style.zoom) || 1;

            switch (event.key) {
                case '+':
                case '=':
                case 'ArrowUp':
                    currentZoom = Math.min(currentZoom + zoomStep, zoomMax);
                    break;
                case '-':
                case '_':
                case 'ArrowDown':
                    currentZoom = Math.max(currentZoom - zoomStep, zoomMin);
                    break;
                case '0':
                case 'Escape':
                    currentZoom = 1;
                    break;
                default:
            }

            document.body.style.zoom = currentZoom.toFixed(1);
            //console.log(currentZoom.toFixed(1));
        }
    }

    document.addEventListener('keydown', toggleZoomScreen);
});
