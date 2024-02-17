"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const router = express_1.default.Router();
const fs_1 = __importDefault(require("fs"));
const js_yaml_1 = __importDefault(require("js-yaml"));
// Read YAML file
const yamlData = fs_1.default.readFileSync("config.yaml", "utf8");
// Parse YAML data
const parsedData = js_yaml_1.default.load(yamlData);
// Define user routes
router.get("/", (req, res) => {
    res.send(parsedData);
});
router.post("/", (req, res) => {
    res.send("POST /users");
});
exports.default = router;
