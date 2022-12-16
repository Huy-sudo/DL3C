var express = require("express");
var router = express.Router();
const prismController = require("../controllers/prismController");

/* GET home page. */
router.get("/getAllPrisms", prismController.getAllPrisms);
router.post("/createPrism", prismController.createPrism);

module.exports = router;
