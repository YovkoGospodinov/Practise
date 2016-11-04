$(document).ready(function () {
    
    $("#bCoaches").on("click", function () {
        $("#entries").hide();
        $("#head").after("<h2>Managers</h2>");
        LoadCoaches();
    });

    $("#bTeams").on("click", function () {
        $("#entries").hide();
        $("#head").after("<h2>Teams</h2>");
        LoadTeams();
    });

    $("#bPlayers").on("click", function () {
        $("#entries").hide();
        $("#head").after("<h2>Players</h2>");
        LoadPlayers();
    });
});