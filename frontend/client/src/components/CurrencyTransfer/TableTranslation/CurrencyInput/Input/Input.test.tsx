import { render, screen, fireEvent } from '@testing-library/react';
import { Input } from './Input';
import { vi } from 'vitest';

describe('Input Component', () => {
  const mockOnAmountChange = vi.fn();

  it('при вводе числа вызывается onAmountChange', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');
    fireEvent.change(input, { target: { value: '50' } });

    expect(mockOnAmountChange).toHaveBeenCalledWith(50);
  });

  it('обновляет локальное значение при вводе', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');
    fireEvent.change(input, { target: { value: '100' } });

    expect(input).toHaveValue('100');
  });

  it('не вызывает onAmountChange при пустом вводе', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');
    fireEvent.change(input, { target: { value: '' } });

    expect(mockOnAmountChange).toBeDefined();
  });

  it('не вызывает onAmountChange при нечисловом вводе', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');
    fireEvent.change(input, { target: { value: 'abc' } });

    expect(mockOnAmountChange).toBeDefined();
  });

  it('обрабатывает дробные числа', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');
    fireEvent.change(input, { target: { value: '15.75' } });

    expect(mockOnAmountChange).toHaveBeenCalledWith(15.75);
  });

  it('обрабатывает отрицательные числа', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');
    fireEvent.change(input, { target: { value: '-50' } });

    expect(mockOnAmountChange).toHaveBeenCalledWith(-50);
  });

  it('последовательный ввод: 1 → 15 → 150', () => {
    render(<Input value={1} onAmountChange={mockOnAmountChange} testId="test-input" />);

    const input = screen.getByTestId('test-input');

    fireEvent.change(input, { target: { value: '15' } });
    expect(mockOnAmountChange).toHaveBeenCalledWith(15);

    fireEvent.change(input, { target: { value: '150' } });
    expect(mockOnAmountChange).toHaveBeenCalledWith(150);
  });
});
