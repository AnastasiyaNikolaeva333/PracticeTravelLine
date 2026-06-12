import styles from './Button.module.css';

type ButtonProps = {
  text: string;
  additionalStyles: string;
  onClick: () => void;
  testId?: string;
};

export const Button = ({ text, additionalStyles, onClick, testId }: ButtonProps) => {
  return (
    <button className={`${styles.button} ${additionalStyles}`} onClick={onClick} data-testid={testId}>
      {text}
    </button>
  );
};
