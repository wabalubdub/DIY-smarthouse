import express, { Request, Response } from "express";
import dotenv from "dotenv";
import routes from "./routes/router";
import cors from "cors";

dotenv.config(); // Load environment variables from .env file

const app = express();
const PORT = process.env.PORT || 3005; // Use port 3000 or process.env.PORT if available

//mount the routs
app.use(cors());
app.use("/api", routes);

// Start the server
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
