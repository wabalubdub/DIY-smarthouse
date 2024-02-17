import express, { Request, Response } from "express";
import dotenv from "dotenv";
import routes from "./routes/router";

dotenv.config(); // Load environment variables from .env file

const app = express();
const PORT = process.env.PORT || 3000; // Use port 3000 or process.env.PORT if available

//mount the routs
app.use("/api", routes);

// Start the server
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
