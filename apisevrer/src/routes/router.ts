import express from "express";
import configRouter from "./config";

const router = express.Router();

// Mount routes
router.use("/config", configRouter);

export default router;
