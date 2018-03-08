var updateGameLog = function(gameLogMessage) {
  $.ajax({
  url: "/GameConsole/Append",
  type: "POST",
  data: {message: gameLogMessage},
  success: function(data){
    console.log("success");
    $("#gameConsole").html(data);
    console.log(data);
    }
  });
};

var inventoryAddItem = function(itemIndex){
  $.ajax({
  url: "/Inventory/AddItem",
  type: "POST",
  data: {index: itemIndex},
  success: function(data){
    console.log(data);
    console.log("item added: " + data._name);
    console.log(data["name"]);
    console.log(data[0]);
    $("#equippableInventory .col-md-12 .row").append('<div class="col-md-3 itemCard"><p class="itemName">' + data._name + '</p><img class="itemImage" src="' + data._imgUrl + '"/></div>')
    }
  })
}

var roomFightEvent = function(){
  var route;
  $.ajax({
    url: "/Room/FightEvent",
    type: "GET",
    success: function(data){
      console.log(data);
      $("#characterHealth").text(data.character._health + "/" + data.character._maxHealth);
      $(".monsterHealthInt").text(data.monster._health + "/" + data.monster._maxHealth);
      route = data.roomRoute;
    }
  });
  return route; 
};
