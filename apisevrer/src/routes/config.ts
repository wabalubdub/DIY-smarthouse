import express, { Request, Response } from "express";
const router = express.Router();
import fs from "fs";
import yaml from "js-yaml";

// Read YAML file
const yamlData = fs.readFileSync("config.yaml", "utf8");

// Parse YAML data
const parsedData = yaml.load(yamlData);

// Define user routes
router.get("/", (req: Request, res: Response) => {
  res.send(parsedData);
});

router.post("/", (req: Request, res: Response) => {
  res.send("POST /users");
});

export default router;
