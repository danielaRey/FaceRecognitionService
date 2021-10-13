"use strict";

var face = {
  start: function () {
    $("#detect").on("click", face.recognize);
    $("#url").on("click", () => $("#errormessage").addClass("d-none"));
    $("#url").keyup((e) => {
      if (e.keyCode === 13) $("#detect").click();
    });
  },

  recognize: async function (e) {
    if (e) {
      e.preventDefault();
      e.stopPropagation();
    }
    $("#errormessage").addClass("d-none");
    $("#result").addClass("d-none");
    $("#detect").prop("disabled", true);

    let imageUrl = $("#url").val();
    try {
      let result = await $.get("Detect", { imageUrl });
      face.showResult(result, imageUrl);
    } catch (err) {
      $("#errormessage").removeClass("d-none").text(err.responseText);
    }

    $("#detect").prop("disabled", false);
    $("#url").val("");
  },

  showResult: function (result, url) {
    $("#resultImage").html('<img src="' + url + '"class="mw-100">');
    $("#result table tbody").html("");

    let tbody = $("#result table tbody")[0];
    if (result && result.length > 0) {
      for (var i = 0; i < result.length; i++) {
        var row = tbody.insertRow(tbody.rows.length);
        var cellName = row.insertCell(0);
        var cellDescription = row.insertCell(1);
        var cellEmotions = row.insertCell(2);
        var cellGlasses = row.insertCell(3);
        var cellMoustache = row.insertCell(4);
        cellName.innerHTML = result[i].name.trim();
        cellDescription.innerHTML = result[i].description.trim();
        cellMoustache.innerHTML = result[i].moustache.trim();
        cellEmotions.innerHTML = `Anger: ${result[
          i
        ].anger.trim()}, Happiness: ${result[
          i
        ].happiness.trim()}, Sadness: ${result[
          i
        ].sadness.trim()}, Surprise: ${result[
          i
        ].surprise.trim()}, Neutral: ${result[i].neutral.trim()}`;
        cellGlasses.innerHTML = result[i].glasses.trim();
      }
    }
    $("#result").removeClass("d-none");
  },
};

face.start();
