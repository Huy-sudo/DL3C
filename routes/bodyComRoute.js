var express = require("express");
var router = express.Router();
const bodyComController = require("../controllers/bodyComController");

/* GET home page. */
router.get("/getAllBodyCom", bodyComController.getAllBodyCom);
router.post("/createBodyCom", bodyComController.createBodyCom);

module.exports = router;
