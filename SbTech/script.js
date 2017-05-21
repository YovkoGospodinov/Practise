var maze = [
        [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1],
        [1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1],
        [1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1],
        [1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0],
        [1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1],
        [1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1]
    ],
    forward = false,
    backward = false,
    left = false,
    right = false,
    positionI,
    positionJ;

(function drawMaze() {
    var table = document.createElement("table");
    table.id = "table";

    for (var i = 0; i < maze.length; i++) {
        var row = document.createElement('tr');
        for (var j = 0; j < maze[i].length; j++) {
            var col = document.createElement("td");
            var flag = maze[i][j];

            if (flag === 1) {
                col.className = "wall";
            } else if (flag === 5) {
                col.className = "enter";
            } else {
                col.className = "path";
            }

            row.appendChild(col);
        }

        table.appendChild(row);
    }

    document.getElementById("maze").appendChild(table);
}());

document.getElementById("entry").addEventListener("click", setEntryPoint);
document.getElementById("result").addEventListener("click", mazeSolver);

function setEntryPoint() {
    positionI = +document.getElementById("pointI").value;
    positionJ = +document.getElementById("pointJ").value;

    maze[positionI][positionJ] = 5;

    var row = document.getElementById("table").rows[positionI];
    var col = row.getElementsByTagName("td")[positionJ];
    col.className = "enter"
}

function isExit(x, y) {
    var result = false;

    if ((x === 0) || (x === maze.length - 1) || (y === 0) || (y === maze[0].length - 1)) {
        result = true;
    }

    return result;
}

function checkMobility() {
    if ((maze[positionI][positionJ + 1] === 0) && (positionJ + 1 < maze[positionJ].length)) {
        right = true;
    }

    if ((maze[positionI][positionJ - 1] === 0) && (positionJ - 1 >= 0)) {
        left = true;
    }

    if ((maze[positionI + 1][positionJ] === 0) && (positionI + 1 < maze.length)) {
        forward = true;
    }

    if ((maze[positionI - 1][positionJ] === 0) && (positionI - 1) >= 0) {
        backward = true;
    }

    document.getElementById("forward").innerHTML += forward;
    document.getElementById("backward").innerHTML += backward;
    document.getElementById("left").innerHTML += left;
    document.getElementById("right").innerHTML += right;
}

function mazeSolver() {
    checkMobility();
}