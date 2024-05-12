mergeInto(LibraryManager.library,
{
	InitSDK_Internal: function (playerPhotoSize, scopes)
	{
		InitSDK(UTF8ToString(playerPhotoSize), scopes);
	},
	
	OpenAuthDialog: function (playerPhotoSize, scopes)
	{
		OpenAuthDialog(UTF8ToString(playerPhotoSize), scopes);
	},

  Authorization: function() {
  return initPlayer()
    .then(player => {
      if (player.getMode() === 'lite') {
        // Игрок не авторизован
        console.log('Player not auth from js');
        return ysdk.auth.openAuthDialog()
          .then(() => {
            // Игрок успешно авторизован
            console.log('Player auth from js');
          })
          .catch(() => {
            // Игрок не авторизован
            console.log('Player not auth from js');
          });
      }
    })
    .catch(err => {
      // Ошибка при инициализации объекта Player
      console.log('Player has inizialize problem from js');
    });
},

	RateGame: function() {
  ysdk.feedback.canReview()
    .then(({ value, reason }) => {
      if (value) {
        ysdk.feedback.requestReview()
          .then(({ feedbackSent }) => {
            console.log(feedbackSent);
            myGameInstance.SendMessage('RateGameController', 'CheckRateFromJS', feedbackSent);
          });
      } else {
        console.log(reason);
      }
    });
  console.log('RateGame complited');
	},

	CheckAuth: function() {
  	myGameInstance.SendMessage('YandexHandler', 'CheckAuthState', player.getMode());
	},

	Hello: function() {
  	window.alert('Hello');
	},

	GetPlayerData: function() {
  	console.log(player.getName());
  	myGameInstance.SendMessage('YandexHandler', 'SetUsernameHandler', player.getName());
	},

	SaveYG: function (jsonData, flush)
	{
		SaveCloud(UTF8ToString(jsonData), flush);
	},
	
	LoadYG: function ()
	{
		LoadCloud();
	},
	
	InitLeaderboard: function ()
	{
		InitLeaderboard();
	},
	
	SetLeaderboardScores: function (nameLB, score)
	{
		SetLeaderboardScores(UTF8ToString(nameLB), score);
	},
	
	GetLeaderboardScores: function (nameLB, maxPlayers, quantityTop, quantityAround, photoSizeLB, auth)
	{
		GetLeaderboardScores(UTF8ToString(nameLB), maxPlayers, quantityTop, quantityAround, UTF8ToString(photoSizeLB), auth);
	},

	FullAdShow: function ()
	{
		FullAdShow();
	},

    RewardedShow: function (id)
	{
		RewardedShow(id);
	},
	
	LanguageRequestInternal: function ()
	{
		LanguageRequest();
	},
	
	RequestingEnvironmentData: function()
	{
		RequestingEnvironmentData();
	},	

	ReviewInternal: function()
	{
		Review();
	},
	
	ActivityRTB1: function(state)
	{
		ActivityRTB1(state);
	},
	
	ActivityRTB2: function(state)
	{
		ActivityRTB2(state);
	},
	
	ExecuteCodeRTB1: function()
	{
		ExecuteCodeRTB1();
	},
	
	ExecuteCodeRTB2: function()
	{
		ExecuteCodeRTB2();
	},
	
	RecalculateRTB1: function(_width, _height, _left, _top)
	{
		RecalculateRTB1(
			UTF8ToString(_width),
			UTF8ToString(_height),
			UTF8ToString(_left),
			UTF8ToString(_top));
	},
	
	RecalculateRTB2: function(_width, _height, _left, _top)
	{
		RecalculateRTB2(
			UTF8ToString(_width),
			UTF8ToString(_height),
			UTF8ToString(_left),
			UTF8ToString(_top));
	},
	
	PaintRBTInternal: function(rbt)
	{
		PaintRBT(UTF8ToString(rbt));
	},
	
	StaticRBTDeactivate: function()
	{
		StaticRBTDeactivate();
	},
	
	BuyPaymentsInternal: function(id)
	{
		BuyPayments(UTF8ToString(id));
	},
	
	GetPaymentsInternal: function()
	{
		GetPayments();
	},
	
	DeletePurchaseInternal: function(id)
	{
		DeletePurchase(UTF8ToString(id));
	},
	
	DeleteAllPurchasesInternal: function()
	{
		DeleteAllPurchases();
	},
	
	PromptShowInternal: function()
	{
		PromptShow();
	},
	
	StickyAdActivityInternal: function(show)
	{
		StickyAdActivity(show);
	},
	
	GetURLFromPage: function () {
        var returnStr = (window.location != window.parent.location) ? document.referrer : document.location.href;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
		
        return buffer;
    },
	
	OpenURL: function (url) {
		var a = document.createElement("a");
		a.setAttribute("href", UTF8ToString(url));
		a.setAttribute("target", "_blank");
		a.click();
	}
});

var FileIO = {

  SaveToLocalStorage : function(key, data) {
	try {
		localStorage.setItem(UTF8ToString(key), UTF8ToString(data));
	}
	catch (e) {
		console.error('Save to Local Storage error: ', e.message);
	}
  },

  LoadFromLocalStorage : function(key) {
    var returnStr = localStorage.getItem(UTF8ToString(key));
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  RemoveFromLocalStorage : function(key) {
    localStorage.removeItem(UTF8ToString(key));
  },

  HasKeyInLocalStorage : function(key) {
	try {
		if (localStorage.getItem(UTF8ToString(key))) {
		  return 1;
		}
		else {
		  return 0;
		}
	}
	catch (e) {
		console.error('Has key in Local Storage error: ', e.message);
		return 0;
	}
  }
};

mergeInto(LibraryManager.library, FileIO);