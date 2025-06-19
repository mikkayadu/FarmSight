import React from "react";
import "../styles/Footer.css";

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-content">
        <div className="footer-left">
          <h3>🌾 FarmSight</h3>
          <p>Empowering smallholder farmers with data-driven insights.</p>
        </div>

        <div className="footer-links">
          <h4>Quick Links</h4>
          <ul>
            <li><a href="/">Home</a></li>
            <li><a href="#about">About</a></li>
            <li><a href="/services">Services</a></li>
            <li><a href="/dashboard">Dashboard</a></li>
          </ul>
        </div>

        <div className="footer-contact">
          <h4>Contact</h4>
          <p>Email: support@farmsight.io</p>
          <p>WhatsApp: +233 555 123 456</p>
        </div>
      </div>

      <div className="footer-bottom">
        <p>© {new Date().getFullYear()} GAIAthon 2025 — All Rights Reserved</p>
      </div>
    </footer>
  );
};

export default Footer;
