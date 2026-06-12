import { fireEvent, render, screen } from '@testing-library/react';
import { vi } from 'vitest';
import { SwapButton } from './SwapButton';

describe('SwapButton Component', () => {
  const mockonSwap = vi.fn();

  it('отображает кнопку с текстом "Обменять"', () => {
    render(<SwapButton onSwap={mockonSwap} testId="swap-button" />);

    const button = screen.getByTestId('swap-button');
    expect(button).toBeInTheDocument();
    expect(button).toHaveTextContent('Обменять');
  });

  it('при клике на кнопку вызывается onSwap', () => {
    render(<SwapButton onSwap={mockonSwap} testId="swap-button" />);

    const button = screen.getByTestId('swap-button');
    fireEvent.click(button);

    expect(mockonSwap).toHaveBeenCalledTimes(1);
  });
});
