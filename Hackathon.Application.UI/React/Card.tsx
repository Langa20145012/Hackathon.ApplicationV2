import React, { ReactNode } from 'react';
import './Card.css';

export interface CardProps {
  title?: string;
  subtitle?: string;
  image?: {
    src: string;
    alt: string;
    position?: 'top' | 'bottom' | 'background';
  };
  content?: ReactNode;
  footer?: ReactNode;
  actions?: ReactNode[];
  width?: string;
  height?: string;
  elevation?: 0 | 1 | 2 | 3;
  className?: string;
  onClick?: () => void;
  hoverable?: boolean;
}

const Card: React.FC<CardProps> = ({
  title,
  subtitle,
  image,
  content,
  footer,
  actions,
  width = '100%',
  height = 'auto',
  elevation = 1,
  className = '',
  onClick,
  hoverable = false,
}) => {
  const cardStyles = {
    width,
    height,
  };

  const cardClasses = [
    'card',
    `elevation-${elevation}`,
    hoverable ? 'hoverable' : '',
    className,
  ].filter(Boolean).join(' ');

  return (
    <div 
      className={cardClasses} 
      style={cardStyles} 
      onClick={onClick}
    >
      {image && image.position === 'top' && (
        <div className="card-image-container">
          <img src={image.src} alt={image.alt} className="card-image" />
        </div>
      )}
      
      {image && image.position === 'background' && (
        <div 
          className="card-background-image" 
          style={{ backgroundImage: `url(${image.src})` }}
        />
      )}

      {(title || subtitle) && (
        <div className="card-header">
          {title && <h2 className="card-title">{title}</h2>}
          {subtitle && <h3 className="card-subtitle">{subtitle}</h3>}
        </div>
      )}

      {content && <div className="card-content">{content}</div>}

      {actions && actions.length > 0 && (
        <div className="card-actions">
          {actions.map((action, index) => (
            <div key={index} className="card-action">
              {action}
            </div>
          ))}
        </div>
      )}

      {footer && <div className="card-footer">{footer}</div>}

      {image && image.position === 'bottom' && (
        <div className="card-image-container">
          <img src={image.src} alt={image.alt} className="card-image" />
        </div>
      )}
    </div>
  );
};

export default Card;
