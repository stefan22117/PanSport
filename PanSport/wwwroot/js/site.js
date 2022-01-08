//menjanje urla, jos nije iskorisceno!!!

function insertUrlParam(key, value) {
    if (history.pushState) {
        let searchParams = new URLSearchParams(window.location.search);
        searchParams.set(key, value);
        let newurl = window.location.protocol + "//" + window.location.host + window.location.pathname + '?' + searchParams.toString();
        window.history.pushState({ path: newurl }, '', newurl);
    }
}
//menjanje urla, jos nije iskorisceno!!!


//USER MESSAGE
$(() => {
    if ($("#UserMessage")) {
        let userMessageDOM = $("#UserMessage");

        userMessageDOM.children(".close-button").click((e) => {
            userMessageDOM.remove();
        })

        let seconds = userMessageDOM.data("seconds");
        if (seconds) {

            setTimeout(() => {
                userMessageDOM.fadeOut({
                    duration: 1000,
                    complete: () => {
                        userMessageDOM.remove();
                    }
                });
            }, seconds * 1000)
        }
    }
}
);

//USER MESSAGE





//PRODUCT IMAGE UPLOAD
$(".subProductImage").click((e) => {
    $(e.target).siblings(".subProductImageFile").click();
});

$(".subProductImageFile").change(function (e) {


    console.log($(".subProductImageFile").val())
    let reader = new FileReader();

    reader.onload = (a) => {
        $(e.target).siblings(".subProductImage").attr("src", a.target.result);
    }

    reader.readAsDataURL(this.files[0]);
})

//PRODUCT IMAGE UPLOAD





//CART
$("#cartHeaderBtn").click(() => {
    $("#cartHeader").toggleClass("d-none");
})

$("#closeCartBtn").click(function () {

    $("#cartHeader").addClass("d-none");
});


function printCartItems(data) {
    let str = "";
    if (data && data.cartItems && data.cartItems.length) {


        str += "<div class='overflow-hidden p-3'>";
        for (let cartItem of data.cartItems) {

            var parameters = [];
            if (cartItem.subProduct.package)
                parameters.push(cartItem.subProduct.package);

            if (cartItem.subProduct.taste)
                parameters.push(cartItem.subProduct.taste);

            if (cartItem.subProduct.size)
                parameters.push(cartItem.subProduct.size);

            if (cartItem.subProduct.color)
                parameters.push(cartItem.subProduct.color);

            let parametersStr = parameters.join(", ");
            //novo
            str += `<div class="row bg-info align-items-center mb-1 rounded text-center text-light">
                    <div class="col-1 p-1">
                        <a href="${cartItem.subProductLink}">
                        <img src="${cartItem.image}"
                             class="rounded"
                             style="
    width:100%;
    height:100%;
    object-fit: contain;" />
                        </a>
                    </div>
                    <div class="col-1">
                        <span>
                            <a
                               class="text-light text-decoration-none"
                               href="${cartItem.subProductLink}">${cartItem.title}</a>
                        </span>
                    </div>
                    <div class="col-1">
                        <span>
                            ${parametersStr}
                        </span>
                    </div>
                    <div class="col-1">
                        <span class="font-weight-bold">
                            ${cartItem.amount}
                        </span>
                    </div>
                    <div class="col-1">
                        <span>
                            <i class="fas fa-times"></i>
                        </span>
                    </div>
                    <div class="col-2 p-0">
                        <span class="font-weight-bold">
                            ${cartItem?.subProduct?.price} din.
                        </span>
                    </div>
                    <div class="col-1">
                        <span>
                            <i class="fas fa-equals"></i>
                        </span>
                    </div>

                    <div class="col-2 p-0">
                        <span class="font-weight-bold">
                            ${cartItem?.subProduct?.price * cartItem?.amount} din.
                        </span>
                    </div>
                    <div class="col-2">
                        <input type="hidden" class="subProductIdCart" value="${cartItem.subProductId}" />
                     <button class="btn-sm btn-warning minusCartItemBtn ${cartItem.Amount == 1 ? "text-secondary" : "text-light"}"
                                ${cartItem.Amount == 1 ? "disabled" : null}>
                            <i class="fas fa-minus-circle"></i>
                        </button>


                        <button class="btn-sm btn-primary plusCartItemBtn"><i class="fas fa-plus-circle"></i></button>
                        <button class="btn-sm btn-danger removeCartItemBtn"><i class="fas fa-trash-alt"></i></button>
                    </div>
                </div>`



            //novo
        }
        str += "</div>";

    }
    else {
        str += `<h2 class="text-danger ml-2">Vasa korpa je prazna...</h2>
            <div class="d-flex justify-content-center align-content-center">

                <a href="/proizvodi"
                   class="btn btn-light text-lg-center cursot-pointer mb-1 text-dark font-weight-bold my-5">
                    Pogledajte proizvode...
                </a>
            </div>`


        //str = "<h2 class='text-danger mb-1'>Vasa korpa je prazna<h2>";
    }
    $("#cartItems").empty();
    $("#cartItems").append(str);

    $("#mainCartItems").empty();
    $("#mainCartItems").append(str);

    buttonsAndSumRender(data);

    cartButtonsRender();
}


function buttonsAndSumRender(data) {
    str = "";
    if (data && data.cartItems && data.cartItems.length) {


        str += `<div class="col-4 d-flex align-items-center justify-content-center">
                <a class="btn-lg btn-success text-decoration-none"
                   href="/cart/CheckOut">
                    Idi na placanje <i class="fas fa-money-bill-wave"></i>
                </a>
            </div>

            <div class="col-4 d-flex align-items-center justify-content-center">

                <button class="btn-lg btn-danger emptyCartBtn">
                    Isprazni korpu <i class="fas fa-trash-alt"></i>
                </button>
            </div>`;


        //str = "";

        //str += "<div class='col-4 d-flex align-items-center justify-content-center'>";
        //str += "<a class='btn-lg btn-success text-decoration-none' href='/cart/CheckOut'>Idi na placanje</a>"
        //str += "</div>";

        //str += "<div class='col-4 d-flex align-items-center justify-content-center'>";
        //str += "<button class='btn-lg btn-danger emptyCartBtn'>"
        //str += "Isprazni korpu <i class='fas fa-trash-alt'></i>"
        //str += "</button>"
        //str += "</div>";

        let cartTotal = data.cartItems.reduce((prev, curr) => prev + (curr?.amount * curr?.subProduct?.price), 0);


        str += "<div class='col-4'>"

        str += "<span class='text-light font-italic'>"
        str += cartTotal + " din.";
        str += "</span>"

        if (cartTotal < 5000) {
            str += "<br /><span class='text-light font-italic'>240 din. (poštarina)</span>"
            cartTotal += 240;
        }
        str += "<hr class='text-light'/><span class='text-light font-italic'><b>" + cartTotal + " din.</b></span>"


        str += "</div>";

    }

    $(".cartButtons").html(str);
}

function cartButtonsRender() {

    $(".minusCartItemBtn").click(function () {
        let subProductId = $(this).parent().children(".subProductIdCart").val();
        $.post("/cart/minusCartItem", { subProductId }, function (data) {
            printCartItems(data);
        });
    });

    $(".plusCartItemBtn").click(function () {
        let subProductId = $(this).parent().children(".subProductIdCart").val();
        $.post("/cart/plusCartItem", { subProductId }, function (data) {
            console.log(data)
            printCartItems(data);
        });
    });

    $(".removeCartItemBtn").click(function () {
        let subProductId = $(this).parent().children(".subProductIdCart").val();
        $.post("/cart/removeCartItem", { subProductId }, function (data) {
            printCartItems(data);
        });
    });

    $(".emptyCartBtn").click(function () {
        $.post("/cart/EmptyCart", {}, function () {
            printCartItems();
        })
    });

}
cartButtonsRender();


//CART






//NOTIFICATION

$("#notificationBtn").click(function () {
    $("#notificationsDiv")
        .stop(true, true)
        .animate({
            height: "toggle",
            opacity: "toggle"
        }, 2000);

});

function NotificationRow(notification) {
    if (notification) {
        notification.dateTime = new Date(notification.dateTime);
        return `
<div style="display:none;" class="row mt-1 bg-info text-light border border-info cursot-pointer notificationRow" data-notificationId="${notification.id}">
                        <div class="col-3 text-info bg-light ">
                            ${notification.dateTime.getDate()}/${notification.dateTime.getMonth()} / ${notification.dateTime.getYear()} ${notification.dateTime.getHours()}: ${notification.dateTime.getMinutes()}</div>
                        <div class="col-9">
                            ${notification.title}
                        </div>
                    </div>
`;
    }
}

function NoMoreNotifications() {

    return `<p style="display:none;" class="p-1 text-center font-italic text-secondary">Nemate novih notifikacija...</p>`
}


$(".notificationRow").click(
    function () {
        notificationClick(this)
    }
);



function notificationClick(e) {

    let row = e;
    console.log('klik')
    let notificationId = $(row).data("notificationid");

    $.post("/notifications/ReadNotification", { id: notificationId }, function ({ nextNotification, notificationsCount }) {

        let rowIndex = $(".notificationRowIndex[data-notificationid='" + notificationId + "']");
        $(rowIndex).removeClass("bg-info text-light border border-light");
        $(rowIndex).addClass("bg-light text-info border border-info");


        if (notificationsCount == 0) {
            $(NoMoreNotifications()).appendTo($(".notificationsDiv2")).slideDown(1000);
            $("#notificationBtn").empty().append(`<i class="far fa-bell text-warning"></i>`);
        }

        $(row).stop(true, false).slideUp(1000,
            function () {
                $(row).remove();
            });


        //
        $(NotificationRow(nextNotification)).appendTo($(".notificationsDiv2"))
            .slideDown(1000, function () { })
            .click(function () {
                notificationClick(this);
            });



        $("#notificationsCount").html(notificationsCount);



    });

}


//NOTIFICATION




//NAVIGATION

$("#navigationBar").slideDown(2000);

$("#navigationLeft").children().css({
    color: "#fff",
    //color: "#343a40",
    transition: "color 4s"
});


//NAVIGATION




//USER MENU

let usermenuClicked = false;
$(".avatar").click(function () {
    if (usermenuClicked) {
        $(".lista").css("right", '-100px').css("opacity", "0");
        usermenuClicked = false;
    }
    else {
        console.log('clicked')
        $(".lista").css("right", '0').css("opacity", "1");
        usermenuClicked = true;
    }
});

$(".lista a").hover(function (e) {
    console.log(this)
    let colorClass = $(this).data("colorclass");


    if (colorClass) {
        $(this).addClass(colorClass);
        $(this).removeClass('text-light');
    }
});

$(".lista a").mouseleave(function (e) {
    let colorClass = $(this).data("colorclass");

    if (colorClass) {
        $(this).removeClass(colorClass);
        $(this).addClass('text-light');
    }
});

//USER MENU
