import React, { useState } from "react";
import "../styles/Navbar.css";
import { Link } from "react-router-dom";

const Navbar = () => {
  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <nav className="navbar">
      <div className="nav-left">
        <h2 className="logo">FarmSight</h2>
        <span className="tagline">Smart Farming From Space</span>
      </div>

      <div className="hamburger" onClick={() => setMenuOpen(!menuOpen)}>
        ☰
      </div>

      <ul className={`nav-links ${menuOpen ? "active" : ""}`}>
        <li><Link to="/">Home</Link></li>
        <li><Link to="/about">About Us</Link></li>
        <li><a href="#services">Services</a></li>
      </ul>

        <div className="nav-auth">
        <Link to="/login" className="sign-in-btn">Sign In</Link>
      </div>
    </nav>
  );
};

export default Navbar;
