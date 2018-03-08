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
  var route = -1;
  $.ajax({
    url: "/Room/FightEvent",
    type: "GET",
    success: function(data){
      console.log("current character health: " + data.character._health);
      $("#characterHealth").text(data.character._health + "/" + data.character._maxHealth);
      $(".monsterHealthInt").text(data.monster._health + "/" + data.monster._maxHealth);
      route = data.roomRoute;
      console.log(data.roomRoute);
    }
  });
  return route;
};

var characterAddItemToEquipped = function(thisItemId){
  $.ajax({
    url: "/Character/AddItemToEquipped/",
    type: "GET",
    data: {itemId: thisItemId},
    success: function(data){
      console.log(data);
      console.log("Your equipped item name is: " + data._name);
      $(".equippedItems .itemCard2:eq(" + data._equippable + ") .itemName").text(data._name);
      $(".equippedItems .itemCard2:eq(" + data._equippable + ") img").attr("src", data._imgUrl);
      updateGameLog("You have equipped " + data._name);
    }
  })
}
